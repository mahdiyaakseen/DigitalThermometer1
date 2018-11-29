using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalThermometerSerialLink
{
    public partial class Demo : Form
    {

        SerialPort comPort = new SerialPort();

   
        string InputData = String.Empty;

        public Demo()
        {
            InitializeComponent();
        }
        

        private void btnSelfTest_Click(object sender, EventArgs e)
        {
            // check any message in queue
            // initiate self test sequence 

            // start polling for status - *TST?
            comPort.Write("*TST");

        }

        private void ckbBackLight_CheckedChanged(object sender, EventArgs e)
        {
            // check if any other command is in progress
            //   if yes 
            //        notify user unit is busy , retry again
            //   else
            if (ckbBackLight.Checked)
            {
                // send command to unit to ON - DISPlay:BACKlight 1
                comPort.Write("DISPlay:BACKlight 1");
                ckbBackLight.Text = "ON";
            }
            else
            {
                // send command to unit to OFF - DISPlay:BACKlight 0
                comPort.Write("DISPlay:BACKlight 0");
                ckbBackLight.Text = "OFF";
            }

        }

        private void ckbBeeper_CheckedChanged(object sender, EventArgs e)
        {
            // check if any other command is in progress
            //   if yes 
            //        notify user unit is busy , retry again
            //   else
            if (ckbBeeper.Checked)
            {
                // send command to unit to ON - SYSTem:BEEPer:STATe 1
                comPort.Write("SYSTem:BEEPer:STATe 1");
                ckbBeeper.Text = "ON";
            }
            else
            {
                // send command to unit to OFF - SYSTem:BEEPer:STATe 0
                comPort.Write("SYSTem:BEEPer:STATe 0");
                ckbBeeper.Text = "OFF";
            }
        }

        private void ckbTimeAndDateDisplayAndLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTimeAndDateDisplayAndLog.Checked)
            {

                Regex rgx = new Regex(@"^$"); // should match 1s, 2s, 3d, 4h time interval format
                if (!string.IsNullOrEmpty(rtbUpdateFrequency.Text) && rgx.IsMatch(rtbUpdateFrequency.Text))
                {
                    //set polling time time interval 

                    // query system date format 
                    comPort.Write("SYSTem: DATE: FORMat ?");
                    // query system date 
                    comPort.Write("SYSTem: DATE?");


                    // query system time 
                    comPort.Write("SYSTem :TIME?");
                    // display to ui
                    //rtbTimeAndDateDisplay.Text = timeAndDate.ToString();

                    // log to CSV 
                }
            }
            else
            {
                // stop polling 
                // log to csv - end of polling
            }
        }

        private void tmrPollForReceivedData_Tick(object sender, EventArgs e)
        {
            InputData = comPort.ReadExisting();
            if (InputData != string.Empty)
            {
               // this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
                rtbTimeAndDateDisplay.Text = InputData;
            }
            else
            {

            }

        }



    }
}
