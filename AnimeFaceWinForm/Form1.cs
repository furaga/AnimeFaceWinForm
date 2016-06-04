using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeFaceWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            screenshotOptionComboBox.SelectedIndex = 0;
            tabControl1.SelectedIndex = 1;
        }

        class bgWorkArg
        {
            public string filepath;
            public int startFrame;
            public int skipFrames;
        }

        bool selectVideoFile()
        {
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
            else
            {
                openFileDialog.FileName = "";
            }

            pathLabel.Text = openFileDialog.FileName;

            return System.IO.File.Exists(openFileDialog.FileName);
        }

        void setUIEnabled(bool isRunning)
        {
            if (isRunning)
            {
                // 実行中はキャンセルボタン以外無効
                selectButton.Enabled = false;
                startFrame.Enabled = false;
                skipFrames.Enabled = false;
                startButton.Enabled = false;
                cancelButton.Enabled = true;

                fpsTextBox.Enabled = false;
                screenshotOptionComboBox.Enabled = false;
                startScreenshotButton.Enabled = false;
                stopScreenshotButton.Enabled = true;
            }
            else
            {
                // 実行してなければキャンセルボタン以外有効
                selectButton.Enabled = true;
                startFrame.Enabled = true;
                skipFrames.Enabled = true;
                startButton.Enabled = true;
                cancelButton.Enabled = false;

                fpsTextBox.Enabled = true;
                startScreenshotButton.Enabled = true;
                screenshotOptionComboBox.Enabled = true;
                stopScreenshotButton.Enabled = false;
            }

            // Tagプロパティに正常なフォルダパス名が入っていればEnableにする
            outputFolderButton.Enabled = isValidOutputFolderButton(outputFolderButton);
            screenshotOutputFolder.Enabled = isValidOutputFolderButton(screenshotOutputFolder);
        }

        /// <summary>
        /// Tagプロパティにフォルダパス名が入っているか
        /// </summary>
        bool isValidOutputFolderButton(Button outputFolderButton)
        {
            string ouputDirPath = outputFolderButton.Tag as string;
            if (ouputDirPath != null && System.IO.Directory.Exists(ouputDirPath))
            {
                return true;
            }
            return false;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            bool result = selectVideoFile();
            outputFolderButton.Tag = getDirectoryName(openFileDialog.FileName);
            setUIEnabled(false);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == false)
            {
                if (false == System.IO.File.Exists(openFileDialog.FileName))
                {
                    bool result = selectVideoFile();
                    if (false == result)
                    {
                        return;
                    }
                }

                var arg = new bgWorkArg()
                {
                    filepath = openFileDialog.FileName,
                    startFrame = (int)startFrame.Value,
                    skipFrames = (int)skipFrames.Value,
                };

                outputFolderButton.Tag = getDirectoryName(arg.filepath);
                backgroundWorker.RunWorkerAsync(arg);
                setUIEnabled(true);
            }
        }

        string getDirectoryName(string inputVideoFilePath)
        {
            string dirName = System.IO.Path.GetFullPath("../output_file/" + System.IO.Path.GetFileNameWithoutExtension(inputVideoFilePath));
            return dirName;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var arg = e.Argument as bgWorkArg;
            string filepath = arg.filepath;
            string saveDir = getDirectoryName(filepath);

            worker.ReportProgress(0);

            using (var capture = new OpenCvSharp.CvCapture(filepath))
            {
                if (capture == null)
                {
                    return;
                }

                if (System.IO.Directory.Exists(saveDir) == false)
                {
                    System.IO.Directory.CreateDirectory(saveDir);
                }

                System.Diagnostics.Process.Start(saveDir);
                capture.PosFrames = arg.startFrame;

                int prevProgress = -1;

                while (true)
                {
                    // キャンセルされてないか定期的にチェック
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    // 画像取得→顔認識
                    using (var cap = capture.RetrieveFrame())
                    {
                        if (cap == null)
                        {
                            e.Result = true;
                            return;
                        }

                        string prefix = capture.PosFrames + "-";
                        AnimeFaceRecognizer.FaceRecognizeAndSaveResults(cap, saveDir, prefix);
                    }

                    // 終了判定
                    if (capture.FrameCount - 1 <= capture.PosFrames + arg.skipFrames)
                    {
                        worker.ReportProgress(100);
                        e.Result = true;
                        return;
                    }

                    capture.PosFrames = capture.PosFrames + arg.skipFrames;

                    // プログレス更新
                    int progress = (int)(100.0f * capture.PosFrames / capture.FrameCount);
                    if ( prevProgress != progress)
                    {
                        worker.ReportProgress(progress);
                    }
                    prevProgress = progress;
                }
            }

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.ProgressPercentage + "%";
            progressBar.Value = e.ProgressPercentage;

            setUIEnabled(true);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled the detection");
            }
            else
            {
                bool result = (bool)e.Result;
                if (result)
                {
                    MessageBox.Show("The detection succeeded!");
                }
                else
                {
                    MessageBox.Show("The detection failed..");
                }
            }

            setUIEnabled(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (null != button)
            {
                string path = button.Tag as string;
                if (path != null && System.IO.Directory.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        enum ScreenshotOptionFlag
        {
            None = 0,
            FaceRecognition = 1,
            SaveScreenshot = 2,
            All = 3,
        }

        ScreenshotOptionFlag getScreenshotOptionFlags()
        {
            ScreenshotOptionFlag option = ScreenshotOptionFlag.None;
            if (screenshotOptionComboBox.Text.Contains("Face recognition"))
            {
                option |= ScreenshotOptionFlag.FaceRecognition;
            }
            if (screenshotOptionComboBox.Text.Contains("Save screenshots"))
            {
                option |= ScreenshotOptionFlag.SaveScreenshot;
            }
            return option;
        }

        private void startScreenshotButton_Click(object sender, EventArgs e)
        {
            if (false == screenshotBackgroundWorker.IsBusy)
            {
                float fps;
                
                if (float.TryParse(fpsTextBox.Text, out fps))
                {
                    var args = new ScreenshotBackgroundWorkArguments()
                    {
                        Prefix = prefixTBox.Text,
                        Fps = fps,
                        OptionFlags = getScreenshotOptionFlags(),
                    };

                    screenshotBackgroundWorker.RunWorkerAsync(args);
                    setUIEnabled(true);
                }
            }
        }

        private void stopScreenshotButton_Click(object sender, EventArgs e)
        {
            screenshotBackgroundWorker.CancelAsync();
        }


        class ScreenshotBackgroundWorkArguments
        {
            public string Prefix { get; set; }
            public float Fps { get; set; }
            public ScreenshotOptionFlag OptionFlags { get; set; }
        }
        
        class ScreenshotBackgroundWorkUserState
        {
            public int ScreenshotCount { get; set; }
            public long ScreenshotTime { get; set; }
            public float RealFps { get; set; }
            public string SaveDirectoryPath { get; set; }
        }

        Bitmap screenshotBmp;

        Bitmap takeScreenshot(Rectangle rect)
        {
            var size = new Size(rect.Width, rect.Height);
            if (screenshotBmp == null)
            {
                screenshotBmp = new Bitmap(rect.Width, rect.Height);
            }

            using (var g = Graphics.FromImage(screenshotBmp))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, size, CopyPixelOperation.SourceCopy);
            }

            return screenshotBmp;
        }

        /// <summary>
        /// スクショ＋顔認識のバックグラウンド処理
        /// </summary>
        private void screenshotBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var args = e.Argument as ScreenshotBackgroundWorkArguments;
            if (args == null || args.Fps < 0.01f)
            {
                return;
            }

            float millisecPerFrame = 1000.0f / args.Fps;
            string saveDir = "../output_screenshot/" + DateTime.Now.ToString("yyyyMMdd_hhmmss");

            string saveScreenshotDir = saveDir + "/screenshot";

            saveDir = System.IO.Path.GetFullPath(saveDir);
            saveScreenshotDir = System.IO.Path.GetFullPath(saveScreenshotDir);

            var userState = new ScreenshotBackgroundWorkUserState()
            {
                ScreenshotCount = 0,
                ScreenshotTime = 0,
                RealFps = args.Fps,
                SaveDirectoryPath = saveDir,
            };
            worker.ReportProgress(0, userState.ScreenshotCount);

            if (args.OptionFlags.HasFlag(ScreenshotOptionFlag.SaveScreenshot))
            {
                if (System.IO.Directory.Exists(saveScreenshotDir) == false)
                {
                    System.IO.Directory.CreateDirectory(saveScreenshotDir);
                }

                System.IO.File.Copy("../script/screenshot2faces.bat", System.IO.Path.Combine(saveDir, "screenshot2faces.bat"));
            }
            else
            {
                if (System.IO.Directory.Exists(saveDir) == false)
                {
                    System.IO.Directory.CreateDirectory(saveDir);
                }
            }

            System.Diagnostics.Process.Start(saveDir);

            List<float> elapsedTimeHistory = new List<float>();

            System.Diagnostics.Stopwatch fpsTimer = new System.Diagnostics.Stopwatch();

            System.Diagnostics.Stopwatch elapsedTimer = System.Diagnostics.Stopwatch.StartNew();
            while (true)
            {
                fpsTimer.Restart();

                // キャンセルされてないか定期的にチェック
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var bmp = takeScreenshot(Screen.PrimaryScreen.Bounds);

                userState.ScreenshotTime = elapsedTimer.ElapsedMilliseconds;

                if (bmp != null)
                {
                    // スクショを保存
                    if (args.OptionFlags.HasFlag(ScreenshotOptionFlag.SaveScreenshot))
                    {
                        string path = System.IO.Path.Combine(saveScreenshotDir, args.Prefix + userState.ScreenshotTime + ".png");
                        bmp.Save(path);
                    }

                    // 顔認識して、顔部分を切り出して保存
                    if (args.OptionFlags.HasFlag(ScreenshotOptionFlag.FaceRecognition))
                    {
                        string prefix = userState.ScreenshotTime + "-";
                        AnimeFaceRecognizer.FaceRecognizeAndSaveResults(bmp, saveDir, prefix);
                    }
                }

                // FPS設定に合わせて、一定時間寝る
                int waitTime = (int)(millisecPerFrame - fpsTimer.ElapsedMilliseconds);
                waitTime = Math.Max(0, waitTime);
                System.Threading.Thread.Sleep(waitTime);

                // 撮影したスクショの枚数
                userState.ScreenshotCount++;

                // fpsの計算
                elapsedTimeHistory.Add(fpsTimer.ElapsedMilliseconds);
                if (elapsedTimeHistory.Sum() >= 1.0f)
                {
                    userState.RealFps = 1000.0f / elapsedTimeHistory.Average();
                    elapsedTimeHistory.Clear();
                }

                // 進捗報告
                worker.ReportProgress(0, userState);
            }
        }

        private void screenshotBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 撮影枚数・FPSを表示
            var userState = e.UserState as ScreenshotBackgroundWorkUserState;
            if (userState != null)
            {
                capturedScreenshotCountLabel.Text = string.Format("Captured {0} Frames", userState.ScreenshotCount);
                realFpsLabel.Text = string.Format("{0:.0} FPS", userState.RealFps);
                screenshotOutputFolder.Tag = userState.SaveDirectoryPath;
            }

            setUIEnabled(true);
        }

        private void screenshotBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Stopped correctly");
            }
            else
            {
                MessageBox.Show("Calcelled unexpectedly");
            }

            setUIEnabled(false);
        }

    }
}
