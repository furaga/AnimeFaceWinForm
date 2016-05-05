namespace AnimeFaceWinForm
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.outputFolderButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.startFrame = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.skipFrames = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stopScreenshotButton = new System.Windows.Forms.Button();
            this.startScreenshotButton = new System.Windows.Forms.Button();
            this.screenshotOutputFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.screenshotOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fpsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.screenshotBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.startFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipFrames)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(257, 238);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(281, 30);
            this.progressBar.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(548, 241);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(54, 21);
            this.progressLabel.TabIndex = 4;
            this.progressLabel.Text = "---%";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(9, 234);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 34);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(117, 234);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(107, 34);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // outputFolderButton
            // 
            this.outputFolderButton.Enabled = false;
            this.outputFolderButton.Location = new System.Drawing.Point(644, 231);
            this.outputFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.outputFolderButton.Name = "outputFolderButton";
            this.outputFolderButton.Size = new System.Drawing.Size(152, 37);
            this.outputFolderButton.TabIndex = 8;
            this.outputFolderButton.Text = "Output Folder";
            this.outputFolderButton.UseVisualStyleBackColor = true;
            this.outputFolderButton.Click += new System.EventHandler(this.outputFolderButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(707, 12);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(37, 34);
            this.selectButton.TabIndex = 9;
            this.selectButton.Text = "..";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // startFrame
            // 
            this.startFrame.Location = new System.Drawing.Point(132, 17);
            this.startFrame.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.startFrame.Name = "startFrame";
            this.startFrame.Size = new System.Drawing.Size(92, 28);
            this.startFrame.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Frame";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Skip Frames";
            // 
            // skipFrames
            // 
            this.skipFrames.Location = new System.Drawing.Point(425, 17);
            this.skipFrames.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.skipFrames.Name = "skipFrames";
            this.skipFrames.Size = new System.Drawing.Size(94, 28);
            this.skipFrames.TabIndex = 14;
            this.skipFrames.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 327);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.cancelButton);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.progressLabel);
            this.tabPage1.Controls.Add(this.outputFolderButton);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "From File";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.skipFrames);
            this.panel5.Controls.Add(this.startFrame);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(6, 93);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(790, 64);
            this.panel5.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.pathLabel);
            this.panel4.Controls.Add(this.selectButton);
            this.panel4.Location = new System.Drawing.Point(6, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 55);
            this.panel4.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Video File Path";
            // 
            // pathLabel
            // 
            this.pathLabel.Location = new System.Drawing.Point(162, 12);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(538, 28);
            this.pathLabel.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.stopScreenshotButton);
            this.tabPage2.Controls.Add(this.startScreenshotButton);
            this.tabPage2.Controls.Add(this.screenshotOutputFolder);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "From Screenshot";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Captured -- Frames";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "--- FPS";
            // 
            // stopScreenshotButton
            // 
            this.stopScreenshotButton.Enabled = false;
            this.stopScreenshotButton.Location = new System.Drawing.Point(115, 233);
            this.stopScreenshotButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopScreenshotButton.Name = "stopScreenshotButton";
            this.stopScreenshotButton.Size = new System.Drawing.Size(107, 34);
            this.stopScreenshotButton.TabIndex = 19;
            this.stopScreenshotButton.Text = "Stop";
            this.stopScreenshotButton.UseVisualStyleBackColor = true;
            this.stopScreenshotButton.Click += new System.EventHandler(this.stopScreenshotButton_Click);
            // 
            // startScreenshotButton
            // 
            this.startScreenshotButton.Location = new System.Drawing.Point(7, 233);
            this.startScreenshotButton.Margin = new System.Windows.Forms.Padding(4);
            this.startScreenshotButton.Name = "startScreenshotButton";
            this.startScreenshotButton.Size = new System.Drawing.Size(100, 34);
            this.startScreenshotButton.TabIndex = 18;
            this.startScreenshotButton.Text = "Start";
            this.startScreenshotButton.UseVisualStyleBackColor = true;
            this.startScreenshotButton.Click += new System.EventHandler(this.startScreenshotButton_Click);
            // 
            // screenshotOutputFolder
            // 
            this.screenshotOutputFolder.Enabled = false;
            this.screenshotOutputFolder.Location = new System.Drawing.Point(634, 230);
            this.screenshotOutputFolder.Margin = new System.Windows.Forms.Padding(4);
            this.screenshotOutputFolder.Name = "screenshotOutputFolder";
            this.screenshotOutputFolder.Size = new System.Drawing.Size(152, 37);
            this.screenshotOutputFolder.TabIndex = 20;
            this.screenshotOutputFolder.Text = "Output Folder";
            this.screenshotOutputFolder.UseVisualStyleBackColor = true;
            this.screenshotOutputFolder.Click += new System.EventHandler(this.outputFolderButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.screenshotOnlyCheckBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.fpsTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 102);
            this.panel1.TabIndex = 28;
            // 
            // screenshotOnlyCheckBox
            // 
            this.screenshotOnlyCheckBox.AutoSize = true;
            this.screenshotOnlyCheckBox.Location = new System.Drawing.Point(15, 56);
            this.screenshotOnlyCheckBox.Name = "screenshotOnlyCheckBox";
            this.screenshotOnlyCheckBox.Size = new System.Drawing.Size(398, 25);
            this.screenshotOnlyCheckBox.TabIndex = 27;
            this.screenshotOnlyCheckBox.Text = "Capturing only (without Face Recognition)";
            this.screenshotOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 21);
            this.label5.TabIndex = 23;
            this.label5.Text = "Capture Speed";
            // 
            // fpsTextBox
            // 
            this.fpsTextBox.Location = new System.Drawing.Point(210, 17);
            this.fpsTextBox.Name = "fpsTextBox";
            this.fpsTextBox.Size = new System.Drawing.Size(133, 28);
            this.fpsTextBox.TabIndex = 26;
            this.fpsTextBox.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 21);
            this.label7.TabIndex = 25;
            this.label7.Text = "FPS";
            // 
            // screenshotBackgroundWorker
            // 
            this.screenshotBackgroundWorker.WorkerReportsProgress = true;
            this.screenshotBackgroundWorker.WorkerSupportsCancellation = true;
            this.screenshotBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.screenshotBackgroundWorker_DoWork);
            this.screenshotBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.screenshotBackgroundWorker_ProgressChanged);
            this.screenshotBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.screenshotBackgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 327);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "AnimeFace WinForm Frontend";
            ((System.ComponentModel.ISupportInitialize)(this.startFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipFrames)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button startButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button outputFolderButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.NumericUpDown startFrame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown skipFrames;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox pathLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button startScreenshotButton;
        private System.Windows.Forms.Button stopScreenshotButton;
        private System.Windows.Forms.CheckBox screenshotOnlyCheckBox;
        private System.Windows.Forms.TextBox fpsTextBox;
        private System.Windows.Forms.Button screenshotOutputFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.ComponentModel.BackgroundWorker screenshotBackgroundWorker;
    }
}

