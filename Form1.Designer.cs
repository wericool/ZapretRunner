namespace ZapretRunner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxBatFiles;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelTestStatus;
        private System.Windows.Forms.ProgressBar progressBarTest;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonRunAsAdmin;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "ZapretRunner by ericool v1.0";
            this.listBoxBatFiles = new System.Windows.Forms.ListBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelTestStatus = new System.Windows.Forms.Label();
            this.progressBarTest = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonRunAsAdmin = new System.Windows.Forms.Button();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.SuspendLayout();
            // 
            // listBoxBatFiles
            // 
            this.listBoxBatFiles.FormattingEnabled = true;
            this.listBoxBatFiles.ItemHeight = 16;
            this.listBoxBatFiles.Location = new System.Drawing.Point(12, 12);
            this.listBoxBatFiles.Name = "listBoxBatFiles";
            this.listBoxBatFiles.Size = new System.Drawing.Size(460, 340);
            this.listBoxBatFiles.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 370);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(220, 40);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Запустить";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(252, 370);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(220, 40);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 420);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(220, 40);
            this.buttonTest.TabIndex = 3;
            this.buttonTest.Text = "Тест";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(252, 420);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(220, 40);
            this.buttonSelectFolder.TabIndex = 4;
            this.buttonSelectFolder.Text = "Выбрать папку";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // labelTestStatus
            // 
            this.labelTestStatus.Location = new System.Drawing.Point(12, 470);
            this.labelTestStatus.Name = "labelTestStatus";
            this.labelTestStatus.Size = new System.Drawing.Size(460, 24);
            this.labelTestStatus.TabIndex = 5;
            this.labelTestStatus.Text = "";
            this.labelTestStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBarTest
            // 
            this.progressBarTest.Location = new System.Drawing.Point(12, 495);
            this.progressBarTest.Name = "progressBarTest";
            this.progressBarTest.Size = new System.Drawing.Size(460, 20);
            this.progressBarTest.TabIndex = 6;
            this.progressBarTest.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarTest.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 520);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(460, 24);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Статус: ...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.Location = new System.Drawing.Point(12, 545);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(460, 24);
            this.checkBoxAutostart.TabIndex = 8;
            this.checkBoxAutostart.Text = "Автозапуск выбранного режима при старте Windows";
            this.checkBoxAutostart.CheckedChanged += new System.EventHandler(this.checkBoxAutostart_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "ZapretRunner by ericool v1.0";
            this.notifyIcon1.Visible = false;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // buttonRunAsAdmin
            // 
            this.buttonRunAsAdmin.Location = new System.Drawing.Point(12, 570);
            this.buttonRunAsAdmin.Name = "buttonRunAsAdmin";
            this.buttonRunAsAdmin.Size = new System.Drawing.Size(460, 40);
            this.buttonRunAsAdmin.TabIndex = 9;
            this.buttonRunAsAdmin.Text = "Запустить с правами администратора";
            this.buttonRunAsAdmin.UseVisualStyleBackColor = true;
            this.buttonRunAsAdmin.Click += new System.EventHandler(this.buttonRunAsAdmin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 620);
            this.Controls.Add(this.buttonRunAsAdmin);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxAutostart);
            this.Controls.Add(this.progressBarTest);
            this.Controls.Add(this.labelTestStatus);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.listBoxBatFiles);
            this.Name = "Form1";
            this.Text = "ZapretRunner by ericool v1.0";
            this.ResumeLayout(false);
        }

        #endregion
    }
}

