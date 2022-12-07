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

namespace AegiClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog openfile = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            openfile.InitialDirectory = @"C\:.ass";
            openfile.DefaultExt = "ass";
            if (openfile.ShowDialog()==DialogResult.OK)
            {
                listBox1.Items.Clear();
                var filelocation = File.ReadAllLines(openfile.FileName);
                List<string> lines = new List<string>(filelocation);
                for (int i = 0; i < lines.Count; i++)
                {
                    listBox1.Items.Add(lines[i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder newFile = new StringBuilder();
            openfile.InitialDirectory = @"C\:ass";
            openfile.DefaultExt = "ass";
            string temp = "";

            string[] file = File.ReadAllLines(openfile.FileName);

            foreach (string line in file)
            {
                if (line.Contains(listBox1.SelectedItem.ToString()))

                {
                    //your selected line ==>> the line you'll change
                    temp = line.Replace(listBox1.SelectedItem.ToString(),textBox1.Text);
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");

            }

            File.WriteAllText(openfile.FileName, newFile.ToString());
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text= listBox1.SelectedItem.ToString();
        }
    }
}
