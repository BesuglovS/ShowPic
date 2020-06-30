namespace ShowPic
{
    partial class PicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.blendPanel = new BlendPanel();
            this.blendTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // blendPanel
            // 
            this.blendPanel.Blend = 0F;
            this.blendPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blendPanel.Image1 = null;
            this.blendPanel.Image2 = null;
            this.blendPanel.Location = new System.Drawing.Point(0, 0);
            this.blendPanel.Name = "blendPanel";
            this.blendPanel.Size = new System.Drawing.Size(800, 450);
            this.blendPanel.TabIndex = 0;
            // 
            // blendTimer
            // 
            this.blendTimer.Interval = 40;
            this.blendTimer.Tick += new System.EventHandler(this.blendTimer_Tick);
            // 
            // PicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blendPanel);
            this.Name = "PicForm";
            this.Text = "PicForm";
            this.Load += new System.EventHandler(this.PicForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PicForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private BlendPanel blendPanel;
        private System.Windows.Forms.Timer blendTimer;
    }
}