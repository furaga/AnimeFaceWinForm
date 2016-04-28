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
            }
            else
            {
                // 実行してなければキャンセルボタン以外有効
                selectButton.Enabled = true;
                startFrame.Enabled = true;
                skipFrames.Enabled = true;
                startButton.Enabled = true;
                cancelButton.Enabled = false;
            }

            string ouputDirPath = outputFolderButton.Tag as string;
            if (ouputDirPath != null && System.IO.Directory.Exists(ouputDirPath))
            {
                outputFolderButton.Enabled = true;
            }
            else
            {
                outputFolderButton.Enabled = false;
            }
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
            string dirName = System.IO.Path.GetFullPath("output/" + System.IO.Path.GetFileNameWithoutExtension(inputVideoFilePath));
            return dirName;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            var arg = e.Argument as bgWorkArg;
            string filepath = arg.filepath;
            string dirName = getDirectoryName(filepath);

            worker.ReportProgress(0);

            using (var capture = new OpenCvSharp.CvCapture(filepath))
            {
                if (capture == null)
                {
                    return;
                }

                if (System.IO.Directory.Exists(dirName) == false)
                {
                    System.IO.Directory.CreateDirectory(dirName);
                }

                System.Diagnostics.Process.Start(dirName);
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

                        // 画像を一旦保存して、pythonに渡す
                        cap.SaveImage(System.IO.Path.GetFullPath("../python/input.png"));

                        // python実行
                        bool result;
                        string output = RunCPython("../python", "detect.py input.png", out result);

                        if (false == result)
                        {
                            e.Result = false;
                            return;
                        }

                        // 結果をパースして、得られた顔領域で画像をトリミングして保存
                        var faces = ParseFaces(output);
                        int faceCnt = 0;
                        foreach (var face in faces)
                        {
                            using (var faceImage = cap.Clone(new OpenCvSharp.CvRect((int)face.X, (int)face.Y, (int)face.Width, (int)face.Height)))
                            {
                                if (System.IO.Directory.Exists(dirName) == false)
                                {
                                    System.IO.Directory.CreateDirectory(dirName);
                                }
                                faceImage.SaveImage(System.IO.Path.Combine(dirName, capture.PosFrames + "-" + (faceCnt++) + ".png"));
                            }
                        }
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


        // Pythonスクリプトの実行
        string RunCPython(string rootDir, string arguments, out bool result)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psInfo = new System.Diagnostics.ProcessStartInfo();

                psInfo.FileName = "python.exe"; // 実行するファイル
                psInfo.Arguments = arguments;
                psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
                psInfo.UseShellExecute = false; // シェル機能を使用しない
                psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
                psInfo.WorkingDirectory = System.IO.Path.GetFullPath(rootDir);
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psInfo); // アプリの実行開始
                string output = p.StandardOutput.ReadToEnd(); // 標準出力の読み取り

                result = true;
                return output;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString() + "\n" + ex.StackTrace);
                result = false;
                return "";
            }
        }

        // pythonからの出力をパースして、顔領域を抽出
        List<RectangleF> ParseFaces(string output)
        {
            var faces = new List<RectangleF>();

            foreach (var _line in output.Split('\n'))
            {
                var line = _line.Trim().Trim('(', ')').Trim();
                var tkns = line.Split(',')
                    .Where(tkn => false == string.IsNullOrWhiteSpace(tkn))
                    .Select(tkn => tkn.Trim())
                    .ToArray();

                if (tkns.Length != 4)
                {
                    continue;
                }

                float x, y, w, h;
                if (float.TryParse(tkns[0], out x) &&
                    float.TryParse(tkns[1], out y) &&
                    float.TryParse(tkns[2], out w) &&
                    float.TryParse(tkns[3], out h))
                {
                    faces.Add(new RectangleF(x, y, w, h));
                }
            }

            return faces;
        }

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            string path = outputFolderButton.Tag as string;
            if (path != null && System.IO.Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
