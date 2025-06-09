using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace stm32_serial
{
    public partial class Form1 : Form
    {
        SerialPort serial;
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = SerialPort.GetPortNames();

        }
        private void serialHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serial.ReadLine();
            this.Invoke((MethodInvoker)delegate
            {
                string[] parts = data.Trim().Split(',');
                //textBox1.AppendText(data + Environment.NewLine);
                //textBox1.Text = data;
                if((parts.Length == 3) && (int.TryParse(parts[0],out int val1))&& (int.TryParse(parts[1], out int val2)) && (int.TryParse(parts[2], out int val3)))
                //if (int.TryParse(data.Trim(), out int value))
                {
                    textBox1.Text = val1.ToString();
                    textBox2.Text = val2.ToString();
                    textBox3.Text = val3.ToString();
                    if (val1 >= progressBar1.Minimum && val1 <= progressBar1.Maximum)
                    {
                        progressBar1.Value = val1;
                    }
                    if (val2/100 >= progressBar1.Minimum && val2/100 <= progressBar1.Maximum)
                    {
                        progressBar2.Value = val2/100;
                    }
                    if (val3/100 >= progressBar1.Minimum && val3/100 <= progressBar1.Maximum)
                    {
                        progressBar3.Value = val3/100;
                    }
                }

            });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Serial_Load();
            MessageBox.Show("LED1 toggle");
            //SerialPort serial = new SerialPort(comboBox1.Text,115200);
            //serial.Open();
            serial.Write("LED1\n\r");
            //serial.Close();
            //SerialPort.o
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LED2 toggle");
            //SerialPort serial = new SerialPort(comboBox1.Text, 115200);
            //serial.Open();
            serial.Write("LED2\n\r");
            //serial.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LED3 toggle");
            //SerialPort serial = new SerialPort(comboBox1.Text, 115200);
            //serial.Open();
            serial.Write("LED3\n\r");
            //serial.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //open
            MessageBox.Show("port open");
       
            serial = new SerialPort(comboBox1.Text, 115200);
            serial.DataReceived += new SerialDataReceivedEventHandler(serialHandler);
            serial.Open();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //close
            MessageBox.Show("port closed");
            //SerialPort serial = new SerialPort(comboBox1.Text, 115200);
            //serial.Open();
            //serial.Write("LED3\n\r");
            serial.Close();
        }
    }
}
