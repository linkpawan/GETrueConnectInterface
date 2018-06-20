using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TrueConnectInterface
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            //Clear flag on builds and tests
            //Properties.Settings.Default.Reset();
            //Properties.Settings.Default.Save();

            SetDefaults();
            CheckTestMode();
            ValidateConfigs(true);
            
        }

        


        private void SetDefaults()
        {
            //Default UI
            btnStartUpload.Visible = false;
            rbOneTime.Checked = true;
            txtTrueConnectPath.Text = @"C:\ProgramData\TrueConnectLink\TrueConnectLink.exe";
            txtTrueConnectPath.ReadOnly = true;
            try
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.ICAO))
                {
                    Text = Properties.Settings.Default.ICAO + "'s " + Text;
                }
            }
            catch
            {

            }
        }

        private void CheckTestMode()
        {
            try
            {
                if (Properties.Settings.Default.hideAutoMode)
                {
                    //When Auto mode is hidden show test connection option
                    rbAuto.Text = "Test Connection";
                    lblAutoInfo.Text = "Select A Folder to Test Connection";
                    if (rbAuto.Checked)
                        btnStartUpload.Text = "Test Connection";
                }
                else
                {
                    //Auto mode
                    rbAuto.Text = "Auto";
                    lblAutoInfo.Text = "This mode will run continually, finding all matching files in the configured location and" + Environment.NewLine + "uploading them to Predix. It will continue to check these locations at a configured interval.";
                    btnStartUpload.Text = "Start Upload";
                }
            }
            catch
            {
                //upon exception show test connection
                rbAuto.Text = "Test Connection";
                lblAutoInfo.Text = "Select A Folder to Test Connection";
                if (rbAuto.Checked)
                    btnStartUpload.Text = "Test Connection";
            }
        }

        private bool ValidateConfigs(bool validateTrueConnectPathOnly)
        {
            var vlaidTCstate = ValidateTrueConnect();
            if (!vlaidTCstate)
            {
                txtTrueConnectPath.BackColor = Color.Red;
                MessageBox.Show("Could not find true connect executable client on given path, please get client and place it on the path:"+Environment.NewLine+txtTrueConnectPath.Text + Environment.NewLine+Environment.NewLine+ "Close this application and re-run once you have resolved the issue.","File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (validateTrueConnectPathOnly)
                return true;
            bool validFileFolder = ValidateForFileorFolderPath();
            if (!validFileFolder)
            {
                lblPath.ForeColor = Color.Red;
                MessageBox.Show("Path is either empty, does not exists or invalid for mode selected." + Environment.NewLine + lblPath.Text + Environment.NewLine + "Please click browse and navigate to appropriate " + lblFileorFolder.Text + " location", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnStartUpload.Visible = false;
                return false;
            }
            return true;
        }

        
        private bool ValidateTrueConnect()
        {
            if (string.IsNullOrEmpty(txtTrueConnectPath.Text))
                return false;

            if (!File.Exists(txtTrueConnectPath.Text))
            {

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(txtTrueConnectPath.Text)))
                    {
                        //If the path does not exists create folder
                        Directory.CreateDirectory(Path.GetDirectoryName(txtTrueConnectPath.Text));
                    }
                    //EXE File does not exists on path dumping the integrated exe
                    //Enhancement: could be potentially fetched from online repo
                    File.WriteAllBytes(txtTrueConnectPath.Text, Properties.Resources.TrueConnectLink);
                }
                catch
                {
                    //Cannot create file or folder.
                    //Command below will return false
                }
            }
            return File.Exists(txtTrueConnectPath.Text);
        }

        private bool ValidateForFileorFolderPath()
        {
            //This validates if the browsed path for file or folder
            try
            {
                if (string.IsNullOrEmpty(lblFileorFolder.Text))
                    return false; // Not Properly Initialized via Mode Selected
                if (string.IsNullOrEmpty(lblPath.Text))
                    return false; //No Path is selected

                FileAttributes attr = File.GetAttributes(lblPath.Text);
                if (lblFileorFolder.Text == "File")
                {
                    if (PathisFolder())
                        return false; //Its suppose to be file but its directory
                    return File.Exists(lblPath.Text); //OK if Exists
                }
                if (lblFileorFolder.Text == "Folder")
                {
                    if (!PathisFolder())
                        return false; //Its suppose to be directory but its file
                    return Directory.Exists(lblPath.Text); //OK if Exists
                }
                return false;//False on everything else
            }
            catch
            {
                return false; //False on exception
            }
            
        }

        private bool PathisFolder()
        {
            return PathisFolder(lblPath.Text);
        }

        private bool PathisFolder(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                var ret = (attr.HasFlag(FileAttributes.Directory));
                return ret;
            }
            catch
            {
                return false;
            }
        }

        private void rbOneTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbOneTime.Checked) return;
            //When Onetime is selected:
            btnStartUpload.Text = "Start Upload";
            lblStatus.Text = "";

            lblOneTimeInfo.Visible = true;
            lblSingleFileInfo.Visible = false;
            lblAutoInfo.Visible = false;

            lblFileorFolder.Text = "Folder";//Browsetype flag: Folder

            //If folder is previously browsed do not prompt to browse again
            //If not valid clear everything
            if (!string.IsNullOrEmpty(lblPath.Text))
            {
                if (!PathisFolder())
                {
                    lblPath.Text = "";
                    btnStartUpload.Visible = false;
                }
            }
        }

        private void rbSingleFile_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbSingleFile.Checked) return;
            //When single file is selected:

            btnStartUpload.Text = "Start Upload";
            lblStatus.Text = "";

            lblOneTimeInfo.Visible = false;
            lblSingleFileInfo.Visible = true;
            lblAutoInfo.Visible = false;

            lblFileorFolder.Text = "File";//Browsetype flag: File
            
            // If file is previously browsed do not prompt to browse again
            //If not valid clear everything

            if (!string.IsNullOrEmpty(lblPath.Text))
            {
                if (PathisFolder())
                {
                    lblPath.Text = "";
                    btnStartUpload.Visible = false;
                }
            }
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            //If Auto is selected:
            if (rbAuto.Checked)
            {
                btnStartUpload.Text = "Start Upload";
                lblStatus.Text = "";

                lblOneTimeInfo.Visible = false;
                lblSingleFileInfo.Visible = false;
                lblAutoInfo.Visible = true;

                lblFileorFolder.Text = "Folder";// Browsetype flag: Folder

                //If folder is previously browsed do not prompt to browse again
                //If not valid clear everything
                if (!string.IsNullOrEmpty(lblPath.Text))
                {
                    if (!PathisFolder())
                    {
                        lblPath.Text = "";
                        btnStartUpload.Visible = false;
                    }
                }
                //Check for autohide flag
                try
                {
                    btnStartUpload.Text = Properties.Settings.Default.hideAutoMode ? "Test Connection" : "Start Upload";
                }
                catch
                {
                    btnStartUpload.Text = "Test Connection";
                    try
                    {
                        //handling exception fetching config xml.
                        Properties.Settings.Default.hideAutoMode = true;
                        Properties.Settings.Default.Save();
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                //If Auto/Test selection changes to something else always change to Start Upload
                btnStartUpload.Text = "Start Upload";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblPath.ForeColor = Color.Black;
            var location = "";
            lblStatus.Text = "";
            //Get location previously selected
            try { location = Properties.Settings.Default.location; } catch { } 
            if (!string.IsNullOrEmpty(location))
            {
                try
                {
                    if (!PathisFolder(location))
                    {
                        location = Path.GetDirectoryName(location);
                    }
                }
                catch { location = ""; }
            }
            

            if (lblFileorFolder.Text == "File")
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                try
                {
                    if (!string.IsNullOrEmpty(lblPath.Text))
                    {
                        if (!PathisFolder())
                        {
                            fileDialog.InitialDirectory = Path.GetDirectoryName(lblPath.Text);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(location))
                            fileDialog.InitialDirectory = location;
                    }
                }
                catch { }
                fileDialog.Multiselect = false;
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblPath.Text = fileDialog.FileName;
                    if(txtTrueConnectPath.BackColor!=Color.Red)
                        btnStartUpload.Visible = true;
                }
            }

            if (lblFileorFolder.Text == "Folder")
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                try
                {
                    if (!string.IsNullOrEmpty(lblPath.Text))
                    {
                        if (PathisFolder())
                        {
                            folderBrowser.SelectedPath = lblPath.Text;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(location))
                            folderBrowser.SelectedPath = location;
                    }
                }
                catch { }
                DialogResult result = folderBrowser.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    lblPath.Text = folderBrowser.SelectedPath;
                    if (txtTrueConnectPath.BackColor != Color.Red)
                        btnStartUpload.Visible = true;
                }
            }
        }

        private void lblPath_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblPath, lblPath.Text);
        }



        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            
            lblStatus.Text = "";
            if (!ValidateConfigs(false))
                return;
            var set = new Settings(txtTrueConnectPath.Text, lblPath.Text, true);
            if (Directory.GetFiles(Path.GetDirectoryName(txtTrueConnectPath.Text), "*.json").Length == 0)
            {
                MessageBox.Show("Application could not create configuration files at: "+ Environment.NewLine+ Path.GetDirectoryName(txtTrueConnectPath.Text)+Environment.NewLine+"Make sure that Application and User has permissions to the folder.","Cannot Proceed",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (!set.ValidState)
            {
                MessageBox.Show("Invalid Settings, Please re-configure settings", "Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Settings s = new Settings(txtTrueConnectPath.Text, lblPath.Text);
                s.ShowDialog();
                return;
            }
            if (rbOneTime.Checked)
            {
                ExecuteTrueConnect("-c:Start -u:" + Properties.Settings.Default.clientId);
            }
            if (rbSingleFile.Checked)
            {
                ExecuteTrueConnect("-c:Upload -u:" + Properties.Settings.Default.clientId + " -p:" + Properties.Settings.Default.secret + " -tenant:" + Properties.Settings.Default.tenant + " -datatype:" + Properties.Settings.Default.datatype + " -dataformat:" + Properties.Settings.Default.dataformat + " -path:\"" + Properties.Settings.Default.location + "\" -e:" + Properties.Settings.Default.endpoint + " -tokurl:" + Properties.Settings.Default.tokenurl);
            }
            if (rbAuto.Checked)
            {
                if (Properties.Settings.Default.hideAutoMode)
                {
                    ExecuteTrueConnect("-c:Test");
                }
                else
                {
                    ExecuteTrueConnect("-c:Auto -u:" + Properties.Settings.Default.clientId);
                }
            }

            
        }

        private void DisplayStatus()
        {
            var startTime = DateTime.UtcNow.AddSeconds(-1);
            bool stayonloop = true;
            int linecounts = 0;
            do
            {
                try
                {
                    string[] files = Directory.GetFiles(Path.GetDirectoryName(txtTrueConnectPath.Text), "*.recordStatus");
                    if (files.Length > 0)
                    {
                        var filetoread = files[0];
                        if (string.IsNullOrEmpty(Path.GetFileNameWithoutExtension(filetoread)))
                        {
                            filetoread = files[1];
                        }
                        var lines = ReadAllLines(filetoread);
                        if (linecounts <= lines.Length)
                        {
                            linecounts = lines.Length;
                            var lastline = lines[linecounts - 1];
                            var splits = lastline.Split(new string[] { "TrueConnect-Link," }, StringSplitOptions.None);
                            var rawdatetime = splits[0];
                            var date = rawdatetime.Split('T')[0];
                            var time = rawdatetime.Split('T')[1].Replace("Z,","");
                            var lineDateTime = new DateTime(Convert.ToInt32(date.Split('-')[0]), Convert.ToInt32(date.Split('-')[1]), Convert.ToInt32(date.Split('-')[2]), Convert.ToInt32(time.Split(':')[0]), Convert.ToInt32(time.Split(':')[1]), Convert.ToInt32(time.Split(':')[2]));
                            if (lineDateTime >= startTime)
                            {
                                var statusSplit = splits[1].Split(',');
                                var status = statusSplit[1] + " " + statusSplit[0];
                                stayonloop = (status != "Stopping Main");
                                if (!stayonloop)
                                {
                                    status = "Completed!";
                                }
                                Invoke((MethodInvoker)delegate {
                                    lblStatus.Text = status;
                                });
                            }
                            else
                            {
                                Invoke((MethodInvoker)delegate {
                                    lblStatus.Text = "Waiting for new Log...";
                                });
                            }
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    stayonloop = false;
                    try
                    {
                        lblStatus.Text = ex.Message;
                        Application.DoEvents();
                    }
                    catch
                    {

                    }
                    
                }
            }
            while (stayonloop);
            if (lblStatus.Text == "Completed!")
            {
                MessageBox.Show(lblStatus.Text, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    btnStartUpload.Enabled = true;

                });
            }
            catch
            { }
        }

        private string[] ReadAllLines(String fileNameAndPath)
        {
            //Reads all lines from file
            try
            {
                System.Collections.Generic.List<string> s = new System.Collections.Generic.List<string>();
                using (FileStream fileStream = File.Open(fileNameAndPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, System.Text.Encoding.Default))
                    {
                        while (streamReader.Peek() > -1)
                        {
                            s.Add(streamReader.ReadLine());
                        }
                    }
                }
                return s.ToArray();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw ex;
            }
        }

        private void ExecuteTrueConnect(string arguments)
        {
            new Thread(() => ExecuteTrueConnectBatch(arguments)).Start();
            
            //For test:
            if (!arguments.Contains("-c:Test"))
                new Thread(() => DisplayStatus()).Start();
        }

        private void ExecuteTrueConnectBatch(string arguments)
        {
            Invoke((MethodInvoker)delegate {
                btnStartUpload.Enabled = false;
                lblStatus.Text = "Executing Commands";
            });

            //Command for bat file
            string cmd = "CD \"C:\\ProgramData\\TrueConnectLink\"" + Environment.NewLine;
            cmd = cmd + "CLS" + Environment.NewLine;
            cmd = cmd + "TrueConnectLink.exe " + arguments;
            
            //Flushing to file on execution dir
            File.WriteAllText(Path.GetDirectoryName(txtTrueConnectPath.Text) + @"\runTCBat.bat", cmd);

            //Start cmd process to run the bat file
            ProcessStartInfo psi = new ProcessStartInfo
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C " + Path.GetDirectoryName(txtTrueConnectPath.Text) + @"\runTCBat.bat",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
            };
            
            var reg = Process.Start(psi);
            
            var output = "";
            using (StreamReader myOutput = reg.StandardOutput)
            {
                output = myOutput.ReadToEnd();
            }


            if (!arguments.Contains("-c:Test"))
                return;

            //Show Messagebox on test completion:
            try
            {
                Invoke((MethodInvoker)delegate {
                    lblStatus.Text="";
                });
                MessageBox.Show(output.Split(new string[] { "-c:Test" }, StringSplitOptions.None)[1], "Test Connection Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
            Invoke((MethodInvoker)delegate {
                btnStartUpload.Enabled = true;

            });
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings(txtTrueConnectPath.Text,lblPath.Text);
            s.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var set = new Settings(txtTrueConnectPath.Text, lblPath.Text);
            set.ShowDialog();
            CheckTestMode();
        }

        private void btnStartUpload_VisibleChanged(object sender, EventArgs e)
        {
            btnSettings.Visible = btnStartUpload.Visible;
        }
    }
}
