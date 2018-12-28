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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTanSo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbChieuSau = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbKichThuoc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbLoaiKenh = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cwvNumber2 = new ReadAndPlay.CustomWaveViewer();
            this.cwvNumber1 = new ReadAndPlay.CustomWaveViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
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
            this.lbMax.Location = new System.Drawing.Point(1038, 32);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(46, 17);
            this.lbMax.TabIndex = 3;
            this.lbMax.Text = "label1";
            // 
            // lbCur
            // 
            this.lbCur.AutoSize = true;
            this.lbCur.Location = new System.Drawing.Point(968, 32);
            this.lbCur.Name = "lbCur";
            this.lbCur.Size = new System.Drawing.Size(46, 17);
            this.lbCur.TabIndex = 2;
            this.lbCur.Text = "label1";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(124, 24);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 24);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "open";
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
            // cmsiSelect
            // 
            this.cmsiSelect.Name = "cmsiSelect";
            this.cmsiSelect.Size = new System.Drawing.Size(118, 24);
            this.cmsiSelect.Text = "Select";
            this.cmsiSelect.Click += new System.EventHandler(this.cmsiSelect_Click);
            // 
            // cmsiCopy
            // 
            this.cmsiCopy.Name = "cmsiCopy";
            this.cmsiCopy.Size = new System.Drawing.Size(118, 24);
            this.cmsiCopy.Text = "Copy";
            this.cmsiCopy.Click += new System.EventHandler(this.cmsiCopy_Click);
            // 
            // cmsiCut
            // 
            this.cmsiCut.Name = "cmsiCut";
            this.cmsiCut.Size = new System.Drawing.Size(118, 24);
            this.cmsiCut.Text = "Cut";
            this.cmsiCut.Click += new System.EventHandler(this.cmsiCut_Click);
            // 
            // cmsiPaste
            // 
            this.cmsiPaste.Name = "cmsiPaste";
            this.cmsiPaste.Size = new System.Drawing.Size(118, 24);
            this.cmsiPaste.Text = "Paste";
            this.cmsiPaste.Click += new System.EventHandler(this.cmsiPaste_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(343, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 90);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbTanSo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 25);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tần số mẫu:";
            // 
            // lbTanSo
            // 
            this.lbTanSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTanSo.Location = new System.Drawing.Point(101, 0);
            this.lbTanSo.Name = "lbTanSo";
            this.lbTanSo.Size = new System.Drawing.Size(130, 25);
            this.lbTanSo.TabIndex = 1;
            this.lbTanSo.Text = "none";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbChieuSau);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(6, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 25);
            this.panel5.TabIndex = 2;
            // 
            // lbChieuSau
            // 
            this.lbChieuSau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChieuSau.Location = new System.Drawing.Point(98, 0);
            this.lbChieuSau.Name = "lbChieuSau";
            this.lbChieuSau.Size = new System.Drawing.Size(130, 25);
            this.lbChieuSau.TabIndex = 1;
            this.lbChieuSau.Text = "none";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Độ dày bit:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbKichThuoc);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(243, 34);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(228, 25);
            this.panel6.TabIndex = 3;
            // 
            // lbKichThuoc
            // 
            this.lbKichThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbKichThuoc.Location = new System.Drawing.Point(108, 0);
            this.lbKichThuoc.Name = "lbKichThuoc";
            this.lbKichThuoc.Size = new System.Drawing.Size(120, 25);
            this.lbKichThuoc.TabIndex = 1;
            this.lbKichThuoc.Text = "none";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Kích thước mẫu";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lbLoaiKenh);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(240, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(228, 25);
            this.panel7.TabIndex = 4;
            // 
            // lbLoaiKenh
            // 
            this.lbLoaiKenh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoaiKenh.Location = new System.Drawing.Point(98, 0);
            this.lbLoaiKenh.Name = "lbLoaiKenh";
            this.lbLoaiKenh.Size = new System.Drawing.Size(130, 25);
            this.lbLoaiKenh.TabIndex = 1;
            this.lbLoaiKenh.Text = "none";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Loại kênh:";
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
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbLoaiKenh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbKichThuoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbChieuSau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbTanSo;
        private System.Windows.Forms.Label label1;
    }
}

