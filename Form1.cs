using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace genericSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //serialPort1.PortName = get
            string[] ports = SerialPort.GetPortNames();
            
            richTextBox1.Text = ("The following serial ports were found:");
            
            // Display each port name to the console.
            foreach (string port in ports)
            {
                comboBox_Ports.Items.Add(port); //https://msdn.microsoft.com/en-us/library/system.windows.forms.combobox.selecteditem(v=vs.110).aspx
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Send data
            try
            {
                if (serialPort1.IsOpen)
                {
                    string text = richTextBox1.Text;
                    serialPort1.WriteLine(text);
                }
            }
            catch (System.TimeoutException)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = comboBox_Ports.SelectedItem;
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = selectedItem.ToString();
                    serialPort1.Open();
                    richTextBox1.Text = " serial ports is connected";
                }
            }
            catch (System.TimeoutException) { }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Recive data
            try
            {
                if (serialPort1.IsOpen)
                {
                    string text = serialPort1.ReadLine();
                    richTextBox1.Text = text;
                }

            }
            catch (System.TimeoutException)
            {

            }

        }
    }
}
