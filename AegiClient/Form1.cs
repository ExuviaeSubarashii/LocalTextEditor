using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            if (openfile.ShowDialog() == DialogResult.OK)
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
            listBox1.Items.Clear();
            var filelocation = File.ReadAllLines(openfile.FileName);
            List<string> lines = new List<string>(filelocation);
            for (int i = 0; i < lines.Count; i++)
            {
                listBox1.Items.Add(lines[i]);
            }

        }
        private void NextLine()
        {
        //    int index = listBox1.SelectedIndex;
        //    //string listboxitem = listBox1.SelectedItem.ToString();
        //    if (listBox1.SelectedIndex != null)
        //    {
        //        if (index < listBox1.Items.Count)
        //        {
        //            //listBox1.Items.RemoveAt(index);
        //            //listBox1.Items.Insert(index + 1, listBox1.SelectedItem.ToString());
        //            listBox1.SetSelected(index + 1, true);
        //        }
        //    }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Edit() == true)
            //{
            //    NextLine();
            //}
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Edit();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        private bool Edit()
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
                    temp = line.Replace(listBox1.SelectedItem.ToString(), textBox1.Text);
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");
            }
            File.WriteAllText(openfile.FileName, newFile.ToString());
            listBox1.Items.Clear();
            var filelocation = File.ReadAllLines(openfile.FileName);
            List<string> lines = new List<string>(filelocation);
            for (int i = 0; i < lines.Count; i++)
            {
                listBox1.Items.Add(lines[i]);
            }
            textBox1.Text = "";
            return true;
        }
    }
}
