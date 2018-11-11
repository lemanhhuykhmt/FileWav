namespace ReadAndPlay
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbCur = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cwvNumber1 = new ReadAndPlay.CustomWaveViewer();
            this.cwvNumber2 = new ReadAndPlay.CustomWaveViewer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbMax);
            this.panel1.Controls.Add(this.lbCur);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 100);
            this.panel1.TabIndex = 0;
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(717, 40);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(46, 17);
            this.lbMax.TabIndex = 3;
            this.lbMax.Text = "label1";
            // 
            // lbCur
            // 
            this.lbCur.AutoSize = true;
            this.lbCur.Location = new System.Drawing.Point(620, 45);
            this.lbCur.Name = "lbCur";
            this.lbCur.Size = new System.Drawing.Size(46, 17);
            this.lbCur.TabIndex = 2;
            this.lbCur.Text = "label1";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(355, 40);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "button2";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(116, 54);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "button1";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cwvNumber2);
            this.panel2.Controls.Add(this.cwvNumber1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1143, 498);
            this.panel2.TabIndex = 1;
            // 
            // cwvNumber1
            // 
            this.cwvNumber1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cwvNumber1.ContextMenuStrip = this.contextMenuStrip1;
            this.cwvNumber1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cwvNumber1.Location = new System.Drawing.Point(0, 0);
            this.cwvNumber1.Name = "cwvNumber1";
            this.cwvNumber1.PenColor = System.Drawing.Color.DodgerBlue;
            this.cwvNumber1.PenWidth = 1F;
            this.cwvNumber1.SamplesPerPixel = 128;
            this.cwvNumber1.Size = new System.Drawing.Size(1143, 250);
            this.cwvNumber1.StartPosition = ((long)(0));
            this.cwvNumber1.TabIndex = 0;
            this.cwvNumber1.WaveStream = null;
            this.cwvNumber1.Click += new System.EventHandler(this.cwvNumber1_Click);
            // 
            // cwvNumber2
            // 
            this.cwvNumber2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cwvNumber2.ContextMenuStrip = this.contextMenuStrip1;
            this.cwvNumber2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cwvNumber2.Location = new System.Drawing.Point(0, 250);
            this.cwvNumber2.Name = "cwvNumber2";
            this.cwvNumber2.PenColor = System.Drawing.Color.DodgerBlue;
            this.cwvNumber2.PenWidth = 1F;
            this.cwvNumber2.SamplesPerPixel = 128;
            this.cwvNumber2.Size = new System.Drawing.Size(1143, 248);
            this.cwvNumber2.StartPosition = ((long)(0));
            this.cwvNumber2.TabIndex = 1;
            this.cwvNumber2.WaveStream = null;
            this.cwvNumber2.Click += new System.EventHandler(this.cwvNumber2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiSelect,
            this.cmsiCopy,
            this.cmsiCut,
            this.cmsiPaste});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 100);
            // 
            // cmsiCopy
            // 
            this.cmsiCopy.Name = "cmsiCopy";
            this.cmsiCopy.Size = new System.Drawing.Size(210, 24);
            this.cmsiCopy.Text = "Copy";
            this.cmsiCopy.Click += new System.EventHandler(this.cmsiCopy_Click);
            // 
            // cmsiCut
            // 
            this.cmsiCut.Name = "cmsiCut";
            this.cmsiCut.Size = new System.Drawing.Size(210, 24);
            this.cmsiCut.Text = "Cut";
            this.cmsiCut.Click += new System.EventHandler(this.cmsiCut_Click);
            // 
            // cmsiPaste
            // 
            this.cmsiPaste.Name = "cmsiPaste";
            this.cmsiPaste.Size = new System.Drawing.Size(210, 24);
            this.cmsiPaste.Text = "Paste";
            this.cmsiPaste.Click += new System.EventHandler(this.cmsiPaste_Click);
            // 
            // cmsiSelect
            // 
            this.cmsiSelect.Name = "cmsiSelect";
            this.cmsiSelect.Size = new System.Drawing.Size(210, 24);
            this.cmsiSelect.Text = "Select";
            this.cmsiSelect.Click += new System.EventHandler(this.cmsiSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbCur;
        private CustomWaveViewer cwvNumber1;
        private CustomWaveViewer cwvNumber2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsiCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsiCut;
        private System.Windows.Forms.ToolStripMenuItem cmsiPaste;
        private System.Windows.Forms.ToolStripMenuItem cmsiSelect;
    }
}

