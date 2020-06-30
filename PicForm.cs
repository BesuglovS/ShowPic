using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShowPic
{
    public partial class PicForm : Form
    {
        List<string> files;
        int picIndex;
        int direction = 1;
        int transitionSpeed = 2; // 1 - 2 sec ; 2 - 1 sec; 3 - 0.5 sec

        public PicForm()
        {
            InitializeComponent();
        }

        public class picsComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var lastOpenParX = x.LastIndexOf('(');
                var xString = x.Substring(lastOpenParX + 1, x.Length - 6 - lastOpenParX);
                var lastOpenParY = y.LastIndexOf('(');
                var yString = y.Substring(lastOpenParY + 1, y.Length - 6 - lastOpenParY);
                int xInt = 0;
                int.TryParse(xString, out xInt);
                int yInt = 0;
                int.TryParse(yString, out yInt);
                return xInt - yInt;
            }
        }

        private void PicForm_Load(object sender, EventArgs e)
        {
            files = MainForm.filenames.OrderBy(s => s, new picsComparer()).ToList();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            picIndex = 0;
            if (files.Count > 0)
            {
                blendPanel.Image1 = Image.FromFile(files[picIndex]);
                blendPanel.Image2 = Image.FromFile(files[picIndex]);
            }
        }

        private void SwitchPic()
        {
            //pictureBox.Image = Image.FromFile(files[picIndex]);
            blendPanel.Image1 = Image.FromFile(files[picIndex]);

            if (direction == 1)
            {
                blendPanel.Image2 = Image.FromFile(files[nextIndex(picIndex)]);
            } else
            {
                blendPanel.Image2 = Image.FromFile(files[prevIndex(picIndex)]);
            }

            switch (transitionSpeed)
            {
                case 1:
                    blendTimer.Interval = 80;
                    break;
                case 2:
                    blendTimer.Interval = 40;
                    break;
                case 3:
                    blendTimer.Interval = 20;
                    break;
                case 4:
                    blendTimer.Interval = 10;
                    break;
            }

            blendTimer.Enabled = true;
        }

        private int prevIndex(int picIndex)
        {
            var result = picIndex - 1;
            if (result < 0)
            {
                result = files.Count - 1;
            }

            return result;
        }

        private int nextIndex(int picIndex)
        {
            var result = picIndex + 1;
            if (result == files.Count)
            {
                result = 0;
            }

            return result;
        }

        private void PicForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                transitionSpeed = 4;
                direction = -1;
            }

            if (e.KeyCode == Keys.D3)
            {
                transitionSpeed = 4;
                direction = 1;
            }

            if (e.KeyCode == Keys.Q)
            {
                transitionSpeed = 3;
                direction = -1;
            }

            if (e.KeyCode == Keys.E)
            {
                transitionSpeed = 3;
                direction = 1;
            }

            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.A))
            {
                transitionSpeed = 2;
                direction = -1;                
            }

            if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.D))
            {
                transitionSpeed = 2;
                direction = 1;                
            }

            if (e.KeyCode == Keys.Z)
            {
                transitionSpeed = 1;
                direction = -1;
            }

            if (e.KeyCode == Keys.C)
            {
                transitionSpeed = 1;
                direction = 1;
            }

            SwitchPic();
        }

        private void blendTimer_Tick(object sender, EventArgs e)
        {
            blendPanel.Blend += 0.04f;

            if (blendPanel.Blend >= 1)
            {
                blendTimer.Enabled = false;

                blendPanel.Image1 = blendPanel.Image2;
                blendPanel.Blend = 0;

                picIndex = (direction == 1) ? nextIndex(picIndex) : prevIndex(picIndex);
            }
        }
    }
}
