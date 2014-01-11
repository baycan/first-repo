using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Smart_Viko_City
{
    public partial class Serial_Port_Open_Form : Form
    {

        public static SerialPort comport = new SerialPort();

                            
        
        public Serial_Port_Open_Form()
        {
            InitializeComponent();
        }

        private void btn_port_open_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (comport.IsOpen) comport.Close();    //comport acık ise kapatılır.

            else
            {
                comport.PortName = combo_COM.Text;
                comport.BaudRate = int.Parse(combo_baud_rate.Text);
                comport.Parity = (Parity)Enum.Parse(typeof(Parity), combo_parity.Text);
                comport.DataBits = int.Parse(combo_data_bits.Text);
                comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), combo_stop_bit.Text);

                try
                {
                    comport.Open();
                }

                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error) MessageBox.Show(this, "Could not open the COM port! Most likely it is already in use, has been removed or is unavalible.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    label_connection.Text = "Connected";
                  
                }
            }                       
        }

        #region  Refresh Com Port List

        private void timer_com_port_Tick(object sender, EventArgs e)
        {
            RefreshComPortList();
        }

        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(combo_COM.Items.Cast<string>(), combo_COM.SelectedItem as string, comport.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                combo_COM.Items.Clear();
                combo_COM.Items.AddRange(OrderedPortNames());
                combo_COM.SelectedItem = selected;
            }
        
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;
            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }


        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }


        #endregion

        private void btn_port_close_Click(object sender, EventArgs e)
        {
            comport.Close();
            if (comport.IsOpen)
            {
                MessageBox.Show("Serial Port could not close");
            }

            else label_connection.Text = "No Connection";
        }



    }
}
