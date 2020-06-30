using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShowPic
{
    public partial class MainForm : Form
    {
        public static List<string> filenames;
        PicForm picform;

        public MainForm()
        {
            InitializeComponent();
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.SelectedPath = @"E:\css\Crash course computer science";

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathString.Text = fbd.SelectedPath;                    
                }
            }
        }

        private void show_Click(object sender, EventArgs e)
        {
            filenames = Directory.GetFiles(pathString.Text, "*.png").ToList();

            picform = new PicForm();
            picform.Show();
        }
    }
}
