using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace SMKSimulator
{

    public partial class Form1 : Form
    {
        ComPort DynonInterfaceSerialport;
        ComPort DynonGPSSerialPort;
        private OpenFileDialog filedialog;
        private DialogResult dialogresult;
        String line = "";
        String wordd = "";
        long currentpos = 0;
        long size = 0;
        ICDWrapper ObjICD;



        Thread SerialThrerad;
        public Form1()
        {
            //Task wait = asyncTask();
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            ObjICD = new ICDWrapper();
            buttonSimulation.Enabled = false;
            try
            {
                #region Dynon MFD Initializing Port.....
                DynonInterfaceSerialport = new ComPort();
                DynonInterfaceSerialport.setParameters(115200, "COM3");
                #endregion
                #region Dynon GPS Initializing Port.....
                DynonGPSSerialPort = new ComPort();
                // DynonGPSSerialPort.setParameters(9600, "COM8");
                #endregion
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please Connect COM3!",
    "Important Message");
                
            }

        }
        // Progress Bar Handler
        public delegate void updateBar();

        private void updateProgreess(int length)
        {
            currentpos += line.Length;
            progressBar1.Value = (int)(((decimal)currentpos / (decimal)size) * (decimal)100);

        }


        private void buttonReadFile_Click(object sender, EventArgs e)
        {
            filedialog = new OpenFileDialog();
            filedialog.Filter = "csv Files(*.csv)|*.csv";

            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo filesize = new FileInfo(filedialog.FileName);
                size = filesize.Length;
                ThreadStart theprogress = new ThreadStart(readFile);


                Thread startprogress = new Thread(theprogress);

                startprogress.Name = "Reading Data Stream";
                startprogress.Priority = ThreadPriority.Highest;

                startprogress.Start();




            }
        }
        private void readFile()
        {
            // dialogresult = filedialog.ShowDialog();



            currentpos = 0;

            StreamReader sr = new StreamReader(new FileStream(filedialog.FileName, FileMode.Open));

            while (!sr.EndOfStream)
            {


                // if (line != null)
                //{
                line = sr.ReadLine();
                listBoxData.Invoke((MethodInvoker)delegate
                {
                    listBoxData.Items.Add(line);
                    updateProgreess(line.Length);
                });
                Thread.Sleep(1);

                //}

                //if (currentSize >= incrementsize)
                //{
                //    currentSize -= incrementsize;
                //    progressBar1.Invoke(new updateBar(this.updateProgreess));
                //}
            }
            //  updateProgreess(100);
            sr.Close();
            DialogResult result = MessageBox.Show("File Reading Done!", "Smart Simulator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                // Invoke()
                buttonReadFile.Invoke((MethodInvoker)delegate
                {
                    buttonReadFile.Enabled = false;
                    buttonSimulation.Enabled = true;
                    progressBar1.Visible = false;

                });
            }




        }
        private void buttonSimulation_Click(object sender, EventArgs e)
        {
            // listBoxFinal.Items.Add(listBoxData.Items.)
            SerialThrerad = new Thread(sendThread);
            SerialThrerad.Start();


            //startprogress.Name = "Reading Data Stream";
            //startprogress.Priority = ThreadPriority.Highest;

            //startprogress.Start();
        }

        public void sendThread()
        {
            for (int i = 0; i < listBoxData.Items.Count; i++)
            {
                string packetBuild = SplitString(Convert.ToString(listBoxData.Items[i]));
                DynonInterfaceSerialport.Write(packetBuild);

                listBoxFinal.Invoke((MethodInvoker)delegate
                {
                    listBoxFinal.Items.Add(packetBuild);

                });


                Thread.Sleep(280);

            }
        }

        public string SplitString(String str)
        {

            String[] words = str.Split(',');
            string packetBuild = "";
            // listBoxFinal.Items.Add("Array Length: " + size);
            for (int i = 0; i < words.Length; i++)
            {
                
                //wordd = wordd + "/" + word;
                //Actual params length =103
                if (words != null && words.Length >= 100)
                {
                    try
                    {
                        string timeGPS = words[3];
                        double lat = Convert.ToDouble(Convert.ToString(words[4]));
                        double longt = Convert.ToDouble(Convert.ToString(words[5]));
                        double alt = Convert.ToDouble(Convert.ToString(words[6]));
                        double alt_pressure = Convert.ToDouble(Convert.ToString(words[19]));
                        double heading = Convert.ToDouble(Convert.ToString(words[17]));
                        double V_velocity = Convert.ToDouble(Convert.ToString(words[24]));
                        double Gnd_Velocity = Convert.ToDouble(Convert.ToString(words[7]));
                        double Gnd_Track = Convert.ToDouble(Convert.ToString(words[8])); //not confirm
                        double IAS = Convert.ToDouble(Convert.ToString(words[18]));
                        double roll = Convert.ToDouble(Convert.ToString(words[16]));
                        double pitch = Convert.ToDouble(Convert.ToString(words[15]));
                        double fuelLevelL = Convert.ToDouble(Convert.ToString(words[64]));
                        double fuelLevelR = Convert.ToDouble(Convert.ToString(words[65]));
                        double RPM= Convert.ToDouble(Convert.ToString(words[59]));
                        double Manifold = Convert.ToDouble(Convert.ToString(words[60]));
                        double FuelPres = Convert.ToDouble(Convert.ToString(words[63]));
                        double OilPres = Convert.ToDouble(Convert.ToString(words[56]));
                        double OilTem = Convert.ToDouble(Convert.ToString(words[57]));
                        double fuelflow = Convert.ToDouble(Convert.ToString(words[61]));
                        double altcur = Convert.ToDouble(Convert.ToString(words[69]));
                        double OAT = Convert.ToDouble(Convert.ToString(words[25]));
                        double mainBusVolt = Convert.ToDouble(Convert.ToString(words[67]));
                        double EGT = Convert.ToDouble(Convert.ToString(words[83]));
                        double CHT = Convert.ToDouble(Convert.ToString(words[82]));
                        double EGT2 = Convert.ToDouble(Convert.ToString(words[81]));
                        double CHT2 = Convert.ToDouble(Convert.ToString(words[80]));
                        double EGT3 = Convert.ToDouble(Convert.ToString(words[79]));
                        double CHT3 = Convert.ToDouble(Convert.ToString(words[78]));
                        double EGT4 = Convert.ToDouble(Convert.ToString(words[77]));
                        double CHT4 = Convert.ToDouble(Convert.ToString(words[76]));
                        double EGT5 = Convert.ToDouble(Convert.ToString(words[75]));
                        double CHT5 = Convert.ToDouble(Convert.ToString(words[74]));
                        double EGT6 = Convert.ToDouble(Convert.ToString(words[73]));
                        double CHT6 = Convert.ToDouble(Convert.ToString(words[72]));
                        double aoa = 0.000;
                        double trueAirspeed = Convert.ToDouble(Convert.ToString(words[26]));
                        //  String buildStr = ObjICD.getTime() + "," + Convert.ToString(words[5]) + "," + Convert.ToString(words[6]) + "," + Convert.ToString(words[7]) + "," + Convert.ToString(words[20]) + "," + Convert.ToString(words[25]) + "," + Convert.ToString(words[25]) + "," + Convert.ToString(words[19]) + "," + Convert.ToString(words[17]) + "," + Convert.ToString(words[16]) + "," + Convert.ToString(words[24]);
                        packetBuild = ObjICD.methodGPSDataToDynon(timeGPS, lat, longt, alt, alt_pressure, heading, V_velocity, Gnd_Velocity, Gnd_Track, IAS, roll, pitch, aoa, fuelLevelL, fuelLevelR,RPM,Manifold,FuelPres,OilPres, OilTem, fuelflow,altcur,OAT,mainBusVolt,EGT,CHT,EGT2,CHT2, EGT3, CHT3, EGT4, CHT4, EGT5, CHT5, EGT6, CHT6);

                        Console.WriteLine(packetBuild);
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                        // return ex.ToString();
                        i++;
                        continue;
                    }
                    finally
                    {
                        //cleanup goes here
                      
                    }

                }
            }

            return packetBuild;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        //public void methodTxDynon() {
        //    try
        //    {
        //        string packetBuild = SplitString
        //        DynonInterfaceSerialport.Write(packetBuild);
        //    }
        //    catch (Exception ex) {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
    }
}
