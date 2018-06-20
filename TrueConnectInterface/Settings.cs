using System;
using System.Windows.Forms;

namespace TrueConnectInterface
{
    public partial class Settings : Form
    {


        // 
        //Things to change for individual clients
        //
        private static string _clientId = "";
        private static string _secret = "";
        private static string _tokenurl = "";
        private static string _endpoint = "";
        private static string _tenant = "";

        private static string _IACO = "";
        private static string _operatorCompany = "";
        private static string _Company = "";

        //


        public Settings(string executablePath)
        {
            InitializeComponent();
            _executablePath = executablePath;
            ValidState = false;
        }

        public Settings(string executablePath, string uploadPath)
        {
            InitializeComponent();
            _executablePath = executablePath;
            _uploadPath = uploadPath;
            ValidState = false;
        }

        public Settings(string executablePath, string uploadPath, bool check)
        {
            InitializeComponent();
            _executablePath = executablePath;
            _uploadPath = uploadPath;
            _checkState = check;
            ValidState = false;
            if (check)
                Settings_Load(new object(), new EventArgs());
        }

        private bool _checkState;
        private string _executablePath;
        private string _uploadPath = "";
        public string OldUploadPath = "";
        public bool ValidState;

        private void Settings_Load(object sender, EventArgs e)
        {
            GetFromSettings();
            if (_checkState)
            {
                Settings_FormClosing(new object(), new FormClosingEventArgs(CloseReason.UserClosing, false));
                Close();
            }
        }


        private void SaveToSettings()
        {
            var runserviceas = textBox1.Text;
            var clientId = textBox2.Text;
            var secret = textBox3.Text;
            var tokenurl = textBox4.Text;
            var endpoint = textBox5.Text;
            var name = textBox6.Text;
            var active = textBox7.Text;
            var tenant = textBox8.Text;
            var location = textBox9.Text;
            var recursive = textBox10.Text;
            var match = textBox11.Text;
            var datatype = textBox12.Text;
            var dataformat = textBox13.Text;
            var pathencodedmetadatatags = textBox14.Text;
            var pollinterval = textBox15.Text;
            var concurrentuploads = textBox16.Text;
            var hideAutomode = cbHideAutoMode.Checked;
            var icao = txtICAO.Text;
            var _operator = txtOperator.Text;
            var engineType = txtEngineType.Text;

            ValidState = !string.IsNullOrEmpty(runserviceas);
            if (ValidState) { ValidState = !string.IsNullOrEmpty(clientId); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(secret); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(tokenurl); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(endpoint); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(name); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(active); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(tenant); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(location); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(recursive); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(match); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(datatype); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(dataformat); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(pathencodedmetadatatags); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(pollinterval); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(concurrentuploads); }

            if (ValidState) { ValidState = !string.IsNullOrEmpty(icao); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(_operator); }
            if (ValidState) { ValidState = !string.IsNullOrEmpty(engineType); }

            if (!ValidState) return;

            try
            {
                Properties.Settings.Default.runserviceas = runserviceas;
                Properties.Settings.Default.clientId = clientId;
                Properties.Settings.Default.secret = secret;
                Properties.Settings.Default.tokenurl = tokenurl;
                Properties.Settings.Default.endpoint = endpoint;
                Properties.Settings.Default.name = name;
                Properties.Settings.Default.active = active;
                Properties.Settings.Default.tenant = tenant;
                Properties.Settings.Default.location = location;
                Properties.Settings.Default.recursive = recursive;
                Properties.Settings.Default.match = match;
                Properties.Settings.Default.datatype = datatype;
                Properties.Settings.Default.dataformat = dataformat;
                Properties.Settings.Default.pathencodedmetadatatags = pathencodedmetadatatags;
                Properties.Settings.Default.pollinterval = pollinterval;
                Properties.Settings.Default.concurrentuploads = concurrentuploads;

                Properties.Settings.Default.ICAO = icao;
                Properties.Settings.Default.Operator = _operator;
                Properties.Settings.Default.EngineType = engineType;

                Properties.Settings.Default.hideAutoMode = hideAutomode;
                Properties.Settings.Default.Save();
            }
            catch { }

        }

        private void GetFromSettings()
        {
            var runserviceas ="";
            var clientId = "";
            var secret = "";
            var tokenurl = "";
            var endpoint = "";
            var name = "";
            var active = "";
            var tenant = "";
            var location = "";
            var recursive = "";
            var match = "";
            var datatype = "";
            var dataformat = "";
            var pathencodedmetadatatags = "";
            var pollinterval = "";
            var concurrentuploads = "";
            var icao = "";
            var _operator= "";
            var enginetype = "";
            var company = "";
            var source = "";
            var hideAutoMode = true;

            try { runserviceas = Properties.Settings.Default.runserviceas; } catch { }
            try { clientId = Properties.Settings.Default.clientId; } catch { }
            try { secret = Properties.Settings.Default.secret; } catch { }
            try { tokenurl = Properties.Settings.Default.tokenurl; } catch { }
            try { endpoint = Properties.Settings.Default.endpoint; } catch { }
            try { name = Properties.Settings.Default.name; } catch { }
            try { active = Properties.Settings.Default.active; } catch { }
            try { tenant = Properties.Settings.Default.tenant; } catch { }
            try { location = Properties.Settings.Default.location; } catch { }
            try { recursive = Properties.Settings.Default.recursive; } catch { }
            try { match = Properties.Settings.Default.match; } catch { }
            try { datatype = Properties.Settings.Default.datatype; } catch { }
            try { dataformat = Properties.Settings.Default.dataformat; } catch { }
            try { pathencodedmetadatatags = Properties.Settings.Default.pathencodedmetadatatags; } catch { }
            try { pollinterval = Properties.Settings.Default.pollinterval; } catch { }
            try { concurrentuploads = Properties.Settings.Default.concurrentuploads; } catch { }
            try { icao = Properties.Settings.Default.ICAO; } catch { }
            try { _operator = Properties.Settings.Default.Operator; } catch { }
            try { enginetype = Properties.Settings.Default.EngineType; } catch { }
            try { company = Properties.Settings.Default.Company; } catch { }
            try { source = Properties.Settings.Default.Source; } catch { }
            try { hideAutoMode = Properties.Settings.Default.hideAutoMode; } catch { }


            //Loading defaults

            textBox1.Text = string.IsNullOrEmpty(runserviceas) ? "false" : runserviceas;
            textBox2.Text = string.IsNullOrEmpty(clientId) ? _clientId : clientId; //Company Specefic Data 
            textBox3.Text = string.IsNullOrEmpty(secret) ? _secret : secret; //Company Specefic Data
            textBox4.Text = string.IsNullOrEmpty(tokenurl) ? _tokenurl : tokenurl; //Company Specefic Data
            textBox5.Text = string.IsNullOrEmpty(endpoint) ? _endpoint : endpoint; //Company Specefic Data
            textBox6.Text = string.IsNullOrEmpty(name) ? "RawLeapEngineData" : name;
            textBox7.Text = string.IsNullOrEmpty(active) ? "true" : active;
            textBox8.Text = string.IsNullOrEmpty(tenant) ? _tenant : tenant;//Company Specefic Data
            textBox9.Text = string.IsNullOrEmpty(location) ? string.IsNullOrEmpty(_uploadPath) ? "" : _uploadPath : string.IsNullOrEmpty(_uploadPath) ? location : _uploadPath;
            textBox10.Text = string.IsNullOrEmpty(recursive) ? "false" : recursive;
            textBox11.Text = string.IsNullOrEmpty(match) ? @".*" : match;//.{12}FFD.{49}$ //.*\\d{14}\\.zip$
            textBox12.Text = string.IsNullOrEmpty(datatype) ? "raw" : datatype;
            textBox13.Text = string.IsNullOrEmpty(dataformat) ? "CEOD" : dataformat;

            //var stringpathencodedmetadatatags = "TailNo" + Environment.NewLine + "([^_]{1,2}_{0,1}[^_]{1,5})_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "EngPos" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-(.{3})-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "FlightDate" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-(\\d{8}-\\d{6})-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "IATA" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-(.{2})-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "FlightNo" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-([^_]{0,10})_*-[^_]{0,8}_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "CityPair" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-([^_]{0,8})_*-\\d{6}[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "ESN" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-(\\d{6})[AB]\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "Channel" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}([AB])\\d{2}$" + Environment.NewLine;
            //stringpathencodedmetadatatags += "Version" + Environment.NewLine + "[^_]{1,2}_{0,1}[^_]{1,5}_*-.{3}-FFD-\\d{8}-\\d{6}-.{2}-[^_]{0,10}_*-[^_]{0,8}_*-\\d{6}[AB]\\(d{2})$" + Environment.NewLine;

            var stringpathencodedmetadatatags = "aircraft_id" + Environment.NewLine + "(.{2}[^-]{1,5})-.*\\d{14}\\.zip$" + Environment.NewLine;
            stringpathencodedmetadatatags += "DownloadedDate" + Environment.NewLine + ".*(\\d{14})\\.zip$" + Environment.NewLine;

            textBox14.Text = string.IsNullOrEmpty(pathencodedmetadatatags) ? stringpathencodedmetadatatags : pathencodedmetadatatags;
            textBox15.Text = string.IsNullOrEmpty(pollinterval) ? "360" : pollinterval;
            textBox16.Text = string.IsNullOrEmpty(concurrentuploads) ? "1" : concurrentuploads;

            txtICAO.Text = string.IsNullOrEmpty(icao) ? _IACO : icao; //Company Specefic Data
            txtOperator.Text = string.IsNullOrEmpty(_operator) ? _operatorCompany : _operator; //Company Specefic Data
            txtCompany.Text = string.IsNullOrEmpty(company) ? _Company : _operator; //Company Specefic Data
            txtSource.Text = string.IsNullOrEmpty(source) ? "TrueConnect Link" : _operator; //Company Specefic Data
            txtEngineType.Text = string.IsNullOrEmpty(enginetype) ? "LEAP" : enginetype; //Company Specefic Data

            cbHideAutoMode.Checked = hideAutoMode;


        }

        private string JsonStaticTags()
        {
            string js = "";

            js = js + "\t\t\t\"statictags\": [" + Environment.NewLine + "";
            js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + "ICAO" + "\"," + Environment.NewLine + "\t\t\t\t\t\"value\": \"" + txtICAO.Text + "\"" + Environment.NewLine + "\t\t\t\t}," + Environment.NewLine;
            js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + "Opertator" + "\"," + Environment.NewLine + "\t\t\t\t\t\"value\": \"" + txtOperator.Text + "\"" + Environment.NewLine + "\t\t\t\t}," + Environment.NewLine;
            js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + "Company" + "\"," + Environment.NewLine + "\t\t\t\t\t\"value\": \"" + txtCompany.Text + "\"" + Environment.NewLine + "\t\t\t\t}," + Environment.NewLine;
            js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + "source_client_version" + "\"," + Environment.NewLine + "\t\t\t\t\t\"value\": \"" + txtSource.Text + "\"" + Environment.NewLine + "\t\t\t\t}," + Environment.NewLine;
            js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + "EngineType" + "\"," + Environment.NewLine + "\t\t\t\t\t\"value\": \"" + txtEngineType.Text + "\"" + Environment.NewLine + "\t\t\t\t}" + Environment.NewLine; // Last line should not include comma (,) after closing curly braces
            js = js + "\t\t\t]" + Environment.NewLine + "";
            return js;
        }

        private string JsonString(bool publish)
        {
            
            string js = "{"+Environment.NewLine+"\t\"runserviceas\":" + textBox1.Text + "," + Environment.NewLine + "";
            js = js + "\t\"clientid\": \"" + textBox2.Text+ "\"," + Environment.NewLine + "";
            js = js + "\t\"secret\": \"" + textBox3.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\"tokenurl\": \"" + textBox4.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\"endpoint\": \"" + textBox5.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\"targets\": [" + Environment.NewLine + "\t\t{" + Environment.NewLine + "";
            js = js + "\t\t\t\"name\": \"" + textBox6.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"active\": " + textBox7.Text + "," + Environment.NewLine + "";

            js = js + "\t\t\t\"dataformat\": \"" + textBox13.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"datatype\": \"" + textBox12.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"location\": \"" + textBox9.Text.Replace(@"\", @"\\") + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"tenant\": \"" + textBox8.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"match\": \"" + textBox11.Text + "\"," + Environment.NewLine + "";
            js = js + "\t\t\t\"pollinterval\": " + textBox15.Text + "," + Environment.NewLine + "";
            js = js + "\t\t\t\"recursive\": " + textBox10.Text + "," + Environment.NewLine + "";

            js = js + "\t\t\t\"pathencodedmetadatatags\": [" + Environment.NewLine + "";
            string[] array = textBox14.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < array.Length; i++)
            {
                if ((i + 2) % 2 == 0)
                {
                    js = js + "\t\t\t\t{" + Environment.NewLine + "\t\t\t\t\t\"tag\": \"" + array[i] + "\"," + Environment.NewLine + "\t\t\t\t\t\"match\": \"" + array[i + 1].Replace(@"\", @"\\") + "\"" + Environment.NewLine + "\t\t\t\t}" + ((i==array.Length-2)?"":","+"") + Environment.NewLine + ""; // ((i==array.Length-2)?"":"," ==> this is to exclude comma on last line
                }
            }
            js = js + "\t\t\t]," + Environment.NewLine + "";
            js = js + JsonStaticTags();
            js = js + "\t\t}" + Environment.NewLine + "\t\t]," + Environment.NewLine + "";
            js = js + "\t\"concurrentuploads\": " + textBox16.Text + "" + Environment.NewLine + "}";

            OldUploadPath = textBox9.Text;

            
            try
            {
                if (publish)
                    System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(_executablePath) + @"\" + textBox2.Text + ".json", js);
            }
            catch
            { ValidState = false; }
            return js;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToSettings();
            if (!_checkState)
            {
                if (!ValidState)
                    e.Cancel = true;
            }
            try
            {
                JsonString(true);
            }
            catch { ValidState = false; }
            
        }
    }
}
