using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_lol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FileCopy(string path)
        {

            using (FileStream from_stream = new FileStream(path, FileMode.Open))
            {
                long file_length = from_stream.Length/3;
                for (int i = 0; i < 3; i++)
                    using (FileStream _to_stream = new FileStream(string.Format("file_{0,3}.txt", i), FileMode.OpenOrCreate))
                    {
                        long _byte_counter = file_length;
                        while (from_stream.CanRead && _byte_counter > 0)
                        {
                            _byte_counter--;
                            _to_stream.WriteByte((byte)from_stream.ReadByte());
                        }
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileCopy(textBox1.Text); 
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
