namespace TrueConnectInterface
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.lblExePath = new System.Windows.Forms.Label();
            this.txtTrueConnectPath = new System.Windows.Forms.TextBox();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.lblAutoInfo = new System.Windows.Forms.Label();
            this.lblSingleFileInfo = new System.Windows.Forms.Label();
            this.lblOneTimeInfo = new System.Windows.Forms.Label();
            this.rbOneTime = new System.Windows.Forms.RadioButton();
            this.rbSingleFile = new System.Windows.Forms.RadioButton();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.gbPaths = new System.Windows.Forms.GroupBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblFileorFolder = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblUploadTarget = new System.Windows.Forms.Label();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbMode.SuspendLayout();
            this.gbPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExePath
            // 
            this.lblExePath.AutoSize = true;
            this.lblExePath.Location = new System.Drawing.Point(6, 16);
            this.lblExePath.Name = "lblExePath";
            this.lblExePath.Size = new System.Drawing.Size(96, 13);
            this.lblExePath.TabIndex = 0;
            this.lblExePath.Text = "True Connect EXE";
            // 
            // txtTrueConnectPath
            // 
            this.txtTrueConnectPath.Location = new System.Drawing.Point(124, 13);
            this.txtTrueConnectPath.Name = "txtTrueConnectPath";
            this.txtTrueConnectPath.Size = new System.Drawing.Size(333, 20);
            this.txtTrueConnectPath.TabIndex = 1;
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.lblAutoInfo);
            this.gbMode.Controls.Add(this.lblSingleFileInfo);
            this.gbMode.Controls.Add(this.lblOneTimeInfo);
            this.gbMode.Controls.Add(this.rbOneTime);
            this.gbMode.Controls.Add(this.rbSingleFile);
            this.gbMode.Controls.Add(this.rbAuto);
            this.gbMode.Location = new System.Drawing.Point(15, 34);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(474, 187);
            this.gbMode.TabIndex = 2;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Mode";
            // 
            // lblAutoInfo
            // 
            this.lblAutoInfo.AutoSize = true;
            this.lblAutoInfo.Location = new System.Drawing.Point(28, 146);
            this.lblAutoInfo.Name = "lblAutoInfo";
            this.lblAutoInfo.Size = new System.Drawing.Size(429, 26);
            this.lblAutoInfo.TabIndex = 5;
            this.lblAutoInfo.Text = "This mode will run continually, finding all matching files in the configured loca" +
    "tion and \r\nuploading them to Predix. It will continue to check these locations a" +
    "t a configured interval.";
            // 
            // lblSingleFileInfo
            // 
            this.lblSingleFileInfo.AutoSize = true;
            this.lblSingleFileInfo.Location = new System.Drawing.Point(24, 97);
            this.lblSingleFileInfo.Name = "lblSingleFileInfo";
            this.lblSingleFileInfo.Size = new System.Drawing.Size(436, 13);
            this.lblSingleFileInfo.TabIndex = 4;
            this.lblSingleFileInfo.Text = "This mode is designed to work as a command line tool that will upload a single fi" +
    "le to Predix.";
            // 
            // lblOneTimeInfo
            // 
            this.lblOneTimeInfo.AutoSize = true;
            this.lblOneTimeInfo.Location = new System.Drawing.Point(25, 39);
            this.lblOneTimeInfo.Name = "lblOneTimeInfo";
            this.lblOneTimeInfo.Size = new System.Drawing.Size(421, 26);
            this.lblOneTimeInfo.TabIndex = 3;
            this.lblOneTimeInfo.Text = "This mode will look for all files in a selected folder and  terminates after all " +
    "found files are \r\nuploaded.";
            // 
            // rbOneTime
            // 
            this.rbOneTime.AutoSize = true;
            this.rbOneTime.Location = new System.Drawing.Point(6, 19);
            this.rbOneTime.Name = "rbOneTime";
            this.rbOneTime.Size = new System.Drawing.Size(71, 17);
            this.rbOneTime.TabIndex = 2;
            this.rbOneTime.TabStop = true;
            this.rbOneTime.Text = "One Time";
            this.rbOneTime.UseVisualStyleBackColor = true;
            this.rbOneTime.CheckedChanged += new System.EventHandler(this.rbOneTime_CheckedChanged);
            // 
            // rbSingleFile
            // 
            this.rbSingleFile.AutoSize = true;
            this.rbSingleFile.Location = new System.Drawing.Point(4, 75);
            this.rbSingleFile.Name = "rbSingleFile";
            this.rbSingleFile.Size = new System.Drawing.Size(73, 17);
            this.rbSingleFile.TabIndex = 1;
            this.rbSingleFile.TabStop = true;
            this.rbSingleFile.Text = "Single File";
            this.rbSingleFile.UseVisualStyleBackColor = true;
            this.rbSingleFile.CheckedChanged += new System.EventHandler(this.rbSingleFile_CheckedChanged);
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.Location = new System.Drawing.Point(6, 122);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.Size = new System.Drawing.Size(47, 17);
            this.rbAuto.TabIndex = 0;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "Auto";
            this.rbAuto.UseVisualStyleBackColor = true;
            this.rbAuto.CheckedChanged += new System.EventHandler(this.rbAuto_CheckedChanged);
            // 
            // gbPaths
            // 
            this.gbPaths.Controls.Add(this.lblPath);
            this.gbPaths.Controls.Add(this.lblFileorFolder);
            this.gbPaths.Controls.Add(this.btnBrowse);
            this.gbPaths.Controls.Add(this.lblUploadTarget);
            this.gbPaths.Controls.Add(this.lblExePath);
            this.gbPaths.Controls.Add(this.txtTrueConnectPath);
            this.gbPaths.Location = new System.Drawing.Point(15, 227);
            this.gbPaths.Name = "gbPaths";
            this.gbPaths.Size = new System.Drawing.Size(474, 109);
            this.gbPaths.TabIndex = 3;
            this.gbPaths.TabStop = false;
            this.gbPaths.Text = "Path";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(124, 88);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 13);
            this.lblPath.TabIndex = 5;
            this.lblPath.TextChanged += new System.EventHandler(this.lblPath_TextChanged);
            // 
            // lblFileorFolder
            // 
            this.lblFileorFolder.AutoSize = true;
            this.lblFileorFolder.Location = new System.Drawing.Point(121, 58);
            this.lblFileorFolder.Name = "lblFileorFolder";
            this.lblFileorFolder.Size = new System.Drawing.Size(0, 13);
            this.lblFileorFolder.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(184, 53);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblUploadTarget
            // 
            this.lblUploadTarget.AutoSize = true;
            this.lblUploadTarget.Location = new System.Drawing.Point(6, 58);
            this.lblUploadTarget.Name = "lblUploadTarget";
            this.lblUploadTarget.Size = new System.Drawing.Size(75, 13);
            this.lblUploadTarget.TabIndex = 2;
            this.lblUploadTarget.Text = "Upload Target";
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartUpload.Location = new System.Drawing.Point(15, 363);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(474, 47);
            this.btnStartUpload.TabIndex = 4;
            this.btnStartUpload.Text = "Start Upload";
            this.btnStartUpload.UseVisualStyleBackColor = true;
            this.btnStartUpload.VisibleChanged += new System.EventHandler(this.btnStartUpload_VisibleChanged);
            this.btnStartUpload.Click += new System.EventHandler(this.btnStartUpload_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(464, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(24, 23);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "*";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(16, 339);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 6;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 422);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStartUpload);
            this.Controls.Add(this.gbPaths);
            this.Controls.Add(this.gbMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "Interface for GE TrueConnect";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.gbPaths.ResumeLayout(false);
            this.gbPaths.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExePath;
        private System.Windows.Forms.TextBox txtTrueConnectPath;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Label lblAutoInfo;
        private System.Windows.Forms.Label lblSingleFileInfo;
        private System.Windows.Forms.Label lblOneTimeInfo;
        private System.Windows.Forms.RadioButton rbOneTime;
        private System.Windows.Forms.RadioButton rbSingleFile;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.Windows.Forms.GroupBox gbPaths;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblFileorFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblUploadTarget;
        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblStatus;
    }
}

