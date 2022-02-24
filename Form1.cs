using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace A_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                textBox1.Text = ((d.TotalFreeSpace) / Convert.ToInt32(Math.Pow(2, 30))).ToString();
                long M = (d.TotalSize - d.TotalFreeSpace) / Convert.ToInt32(Math.Pow(2, 30));
                textBox2.Text = M.ToString();
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                textBox1.Text = ((d.TotalFreeSpace)/ Convert.ToInt32(Math.Pow(2, 30))).ToString();
                long M = (d.TotalSize - d.TotalFreeSpace) / Convert.ToInt32(Math.Pow(2, 30));
                textBox2.Text = M.ToString();       
            }
        }
        private List<string> F = new List<string>() { };
        private string FF = "";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            F.Clear();
            richTextBox1.Clear();
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                F.Add(openFileDialog1.FileName);
                richTextBox1.Text = openFileDialog1.FileName;               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FF = "";
            richTextBox2.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FF = folderBrowserDialog1.SelectedPath;
                richTextBox2.Text = FF;                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (F.Count > 0 & FF.Length > 0)
            {
                foreach (string file in F)
                {
                    string FileName = Path.GetFileName(file);
                    File.Copy(file, Path.Combine(FF, FileName));
                    MessageBox.Show("Копирование завершено", "Копировать");                    
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (F.Count > 0 & FF.Length > 0)
            {
                foreach (string file in F)
                {
                    string FileName = Path.GetFileName(file);
                    File.Move(file, Path.Combine(FF, FileName));
                    MessageBox.Show("Файл перемещён", "Переместить");                    
                }
            }            
        }
    }
}
