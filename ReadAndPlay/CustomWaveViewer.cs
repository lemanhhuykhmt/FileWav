using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadAndPlay
{
    public class CustomWaveViewer : System.Windows.Forms.UserControl
    {
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        private bool isPlaying = false;
        private Panel pnlTop;
        private Panel pnlBot;
        private Panel pnlMid;
        private Panel pnlVerticalLineEnd;
        private Panel pnlVerticalLineBegin;
        private Label lbLeftTime;
        private Panel pnlVerticalLineLeft;
        private Label lbRightTime;
        private Panel pnlVerticalLineRight;
        private Label lbCurTime;
        private Panel pnlVelticalLineCur;
        private Timer timer1;






        private void pnlMid_MouseDown(object sender, MouseEventArgs e)
        {
            if (waveStream == null) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                startPos = e.Location;
                oldPos = new Point(-1, -1);
                mouseDrag = true;
                //DrawVerticalLine(e.Location.X, Color.Black);
                pnlVerticalLineBegin.Visible = true;
                pnlVerticalLineBegin.Size = new Size(1, this.pnlMid.Height);
                pnlVerticalLineBegin.Location = new Point(e.Location.X, 0);
                pnlVerticalLineBegin.Parent = pnlMid;
                pnlVerticalLineBegin.BackColor = Color.Green;

                //
                pnlVerticalLineEnd.Visible = true;
                pnlVerticalLineEnd.Size = new Size(1, this.pnlMid.Height);
                pnlVerticalLineEnd.Location = new Point(oldPos.X, 0);
                pnlVerticalLineEnd.Parent = pnlMid;
                pnlVerticalLineEnd.BackColor = Color.Green;
            }
            else if(e.Button == MouseButtons.Left)
            {
                if(isPlaying == false)
                {
                    int x = e.Location.X;
                    waveStream.Position = (long)(1.0 * waveStream.Length * x / this.pnlMid.Width);
                    pnlVelticalLineCur.Location = new Point(x, 0);
                    lbCurTime.Location = new Point(x - lbCurTime.Size.Width / 2, 0);
                    setTextCurTime();
                    lbCurTime.BringToFront();
                }
            }
        }       
        private void pnlMid_MouseMove(object sender, MouseEventArgs e)
        {
            if (waveStream == null) return;
            if (mouseDrag)
            {
               // DrawVerticalLine(e.X, Color.Black);
                //if (oldPos.X >= 0) { DrawVerticalLine(oldPos.X, Color.White); }
                oldPos = e.Location;
                //if (mousePos.X != -1)
                //{
                //DrawVerticalLine(oldPos.X, Color.Black);
                pnlVerticalLineEnd.Location = new Point(oldPos.X, 0);
                //}
                //Painting();
            }
            
        }        
        private void pnlMid_MouseUp(object sender, MouseEventArgs e)
        {
            if (waveStream == null) return;
            if (mouseDrag && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mouseDrag = false;
                //DrawVerticalLine(startPos.X, Color.Black);

                if (e.X == -1) return;
                //DrawVerticalLine(mousePos.X, Color.Black);

                int leftSample = (int)(StartPosition / bytesPerSample + samplesPerPixel * Math.Min(startPos.X, e.X));
                int rightSample = (int)(StartPosition / bytesPerSample + samplesPerPixel * Math.Max(startPos.X, e.X));
                if(rightSample - leftSample < 3000)
                {
                    pnlVerticalLineBegin.Visible = false;
                    pnlVerticalLineEnd.Visible = false;
                    return;
                }
                Zoom(leftSample, rightSample);

            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle) FitToScreen();
            pnlVerticalLineBegin.Visible = false;
            pnlVerticalLineEnd.Visible = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            FitToScreen();
        }

        private System.ComponentModel.IContainer components;
        private WaveStream waveStream;
        private int samplesPerPixel = 128;
        private long startPosition;
        private int bytesPerSample;
        /// <summary>
        /// Creates a new WaveViewer control
        /// </summary>
        public CustomWaveViewer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.DoubleBuffered = true;

            this.PenColor = Color.DodgerBlue;
            this.PenWidth = 1;
            this.pnlMid.AllowDrop = true;
        }

        /// <summary>
        /// sets the associated wavestream
        /// </summary>
        public WaveStream WaveStream
        {
            get
            {
                return waveStream;
            }
            set
            {
                waveStream = value;
                isChangedImage = true;
                if (waveStream != null)
                {
                    bytesPerSample = (waveStream.WaveFormat.BitsPerSample / 8) * waveStream.WaveFormat.Channels;
                }
                this.Invalidate();
                if (waveStream != null && waveStream.Position == 0)
                {
                    //pnlVelticalLineCur = new Panel();
                    pnlVelticalLineCur.Visible = true;
                    pnlVelticalLineCur.Location = new Point(1, 0);
                    pnlVelticalLineCur.Parent = pnlMid;
                    pnlVelticalLineCur.Size = new Size(1, this.pnlMid.Height);
                    pnlVelticalLineCur.BackColor = Color.Yellow;

                    //lbCurTime = new Label();
                    lbCurTime.Visible = true;
                    lbCurTime.BackColor = Color.Transparent;
                    //lbCurTime.AutoSize = false;
                    //lbCurTime.Size = new Size(50, 15);
                    lbCurTime.Location = new Point(-lbCurTime.Size.Width / 2, 0);
                    lbCurTime.Parent = pnlMid;



                    pnlVerticalLineLeft.Visible = true;
                    pnlVerticalLineLeft.Size = new Size(5, this.pnlMid.Height);
                    pnlVerticalLineLeft.Location = new Point(0, 0);
                    pnlVerticalLineLeft.Parent = pnlMid;
                    pnlVerticalLineLeft.BackColor = Color.Red;
                    lbLeftTime.Visible = true;
                    lbLeftTime.BackColor = Color.Transparent;
                    lbLeftTime.Location = new Point(-lbLeftTime.Size.Width / 2, 0);
                    lbLeftTime.Parent = pnlMid;

                    pnlVerticalLineRight.Visible = true;
                    pnlVerticalLineRight.Size = new Size(5, this.pnlMid.Height);
                    pnlVerticalLineRight.Location = new Point(this.pnlMid.Width - 1 - pnlVerticalLineRight.Width, 0);
                    pnlVerticalLineRight.Parent = pnlMid;
                    pnlVerticalLineRight.BackColor = Color.Red;
                    lbRightTime.Visible = true;
                    lbRightTime.BackColor = Color.Transparent;
                    lbRightTime.Location = new Point(this.pnlMid.Width - 1 - pnlVerticalLineRight.Width - lbRightTime.Size.Width / 2, 0);
                    lbRightTime.Parent = pnlMid;
                }
            }
        }

        /// <summary>
        /// The zoom level, in samples per pixel
        /// </summary>
        public int SamplesPerPixel
        {
            get
            {
                return samplesPerPixel;
            }
            set
            {
                isChangedImage = true;
                samplesPerPixel = Math.Max(1, value);
                //Painting();
            }
        }

        /// <summary>
        /// Start position (currently in bytes)
        /// </summary>
        public long StartPosition
        {
            get
            {
                return startPosition;
            }
            set
            {
                startPosition = value;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMid = new System.Windows.Forms.Panel();
            this.pnlVerticalLineEnd = new System.Windows.Forms.Panel();
            this.pnlVerticalLineBegin = new System.Windows.Forms.Panel();
            this.lbLeftTime = new System.Windows.Forms.Label();
            this.pnlVerticalLineLeft = new System.Windows.Forms.Panel();
            this.lbRightTime = new System.Windows.Forms.Label();
            this.pnlVerticalLineRight = new System.Windows.Forms.Panel();
            this.lbCurTime = new System.Windows.Forms.Label();
            this.pnlVelticalLineCur = new System.Windows.Forms.Panel();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(843, 24);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBot
            // 
            this.pnlBot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 464);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(843, 27);
            this.pnlBot.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlMid
            // 
            this.pnlMid.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMid.Controls.Add(this.pnlVerticalLineEnd);
            this.pnlMid.Controls.Add(this.pnlVerticalLineBegin);
            this.pnlMid.Controls.Add(this.lbLeftTime);
            this.pnlMid.Controls.Add(this.pnlVerticalLineLeft);
            this.pnlMid.Controls.Add(this.lbRightTime);
            this.pnlMid.Controls.Add(this.pnlVerticalLineRight);
            this.pnlMid.Controls.Add(this.lbCurTime);
            this.pnlMid.Controls.Add(this.pnlVelticalLineCur);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 24);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(843, 440);
            this.pnlMid.TabIndex = 2;
            this.pnlMid.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMid_DragDrop);
            this.pnlMid.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlMid_DragOver);
            this.pnlMid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMid_MouseDown);
            this.pnlMid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMid_MouseMove);
            this.pnlMid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMid_MouseUp);
            // 
            // pnlVerticalLineEnd
            // 
            this.pnlVerticalLineEnd.BackColor = System.Drawing.Color.Yellow;
            this.pnlVerticalLineEnd.Location = new System.Drawing.Point(318, 173);
            this.pnlVerticalLineEnd.Name = "pnlVerticalLineEnd";
            this.pnlVerticalLineEnd.Size = new System.Drawing.Size(10, 100);
            this.pnlVerticalLineEnd.TabIndex = 2;
            this.pnlVerticalLineEnd.Visible = false;
            // 
            // pnlVerticalLineBegin
            // 
            this.pnlVerticalLineBegin.BackColor = System.Drawing.Color.Yellow;
            this.pnlVerticalLineBegin.Location = new System.Drawing.Point(293, 41);
            this.pnlVerticalLineBegin.Name = "pnlVerticalLineBegin";
            this.pnlVerticalLineBegin.Size = new System.Drawing.Size(10, 100);
            this.pnlVerticalLineBegin.TabIndex = 6;
            this.pnlVerticalLineBegin.Visible = false;
            // 
            // lbLeftTime
            // 
            this.lbLeftTime.AutoSize = true;
            this.lbLeftTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbLeftTime.Location = new System.Drawing.Point(563, 95);
            this.lbLeftTime.Name = "lbLeftTime";
            this.lbLeftTime.Size = new System.Drawing.Size(0, 17);
            this.lbLeftTime.TabIndex = 3;
            this.lbLeftTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLeftTime.Visible = false;
            // 
            // pnlVerticalLineLeft
            // 
            this.pnlVerticalLineLeft.BackColor = System.Drawing.Color.Red;
            this.pnlVerticalLineLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlVerticalLineLeft.Location = new System.Drawing.Point(610, 95);
            this.pnlVerticalLineLeft.Name = "pnlVerticalLineLeft";
            this.pnlVerticalLineLeft.Size = new System.Drawing.Size(10, 100);
            this.pnlVerticalLineLeft.TabIndex = 4;
            this.pnlVerticalLineLeft.Visible = false;
            this.pnlVerticalLineLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlVerticalLineLeft_MouseDown);
            this.pnlVerticalLineLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlVerticalLineLeft_MouseUp);
            // 
            // lbRightTime
            // 
            this.lbRightTime.AutoSize = true;
            this.lbRightTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbRightTime.Location = new System.Drawing.Point(393, 95);
            this.lbRightTime.Name = "lbRightTime";
            this.lbRightTime.Size = new System.Drawing.Size(0, 17);
            this.lbRightTime.TabIndex = 1;
            this.lbRightTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRightTime.Visible = false;
            // 
            // pnlVerticalLineRight
            // 
            this.pnlVerticalLineRight.BackColor = System.Drawing.Color.Red;
            this.pnlVerticalLineRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlVerticalLineRight.Location = new System.Drawing.Point(440, 95);
            this.pnlVerticalLineRight.Name = "pnlVerticalLineRight";
            this.pnlVerticalLineRight.Size = new System.Drawing.Size(10, 100);
            this.pnlVerticalLineRight.TabIndex = 2;
            this.pnlVerticalLineRight.Visible = false;
            this.pnlVerticalLineRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlVerticalLineRight_MouseDown);
            this.pnlVerticalLineRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlVerticalLineRight_MouseUp);
            // 
            // lbCurTime
            // 
            this.lbCurTime.AutoSize = true;
            this.lbCurTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCurTime.Location = new System.Drawing.Point(136, 71);
            this.lbCurTime.Name = "lbCurTime";
            this.lbCurTime.Size = new System.Drawing.Size(0, 17);
            this.lbCurTime.TabIndex = 0;
            this.lbCurTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCurTime.Visible = false;
            // 
            // pnlVelticalLineCur
            // 
            this.pnlVelticalLineCur.BackColor = System.Drawing.Color.Yellow;
            this.pnlVelticalLineCur.Location = new System.Drawing.Point(183, 71);
            this.pnlVelticalLineCur.Name = "pnlVelticalLineCur";
            this.pnlVelticalLineCur.Size = new System.Drawing.Size(10, 100);
            this.pnlVelticalLineCur.TabIndex = 0;
            this.pnlVelticalLineCur.Visible = false;
            // 
            // CustomWaveViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Name = "CustomWaveViewer";
            this.Size = new System.Drawing.Size(843, 491);
            this.pnlMid.ResumeLayout(false);
            this.pnlMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {

            int x = (int)(1.0 * waveStream.Position / waveStream.Length * this.pnlMid.Width);
            pnlVelticalLineCur.Location = new Point(x, 0);
            lbCurTime.Location = new Point(x - lbCurTime.Size.Width / 2, 0);
            setTextCurTime();
            lbCurTime.BringToFront();
            if (waveStream.Position > waveStream.Length)
            {
                Stop();
            }
        }
        private bool isScroll = false;
        private Bitmap bmTemp = null;
        private bool isChangedImage = true;
        private Point oldPos = new Point(-1, -1);
        private Point startPos;
        private bool mouseDrag = false;
        private int mouseDragSelect = 0;

        private void pnlVerticalLineRight_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDragSelect = 2;
            Panel c = sender as Panel;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void pnlVerticalLineRight_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDragSelect = 0;
        }

        private void pnlVerticalLineLeft_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDragSelect = 1;
            Panel c = sender as Panel;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void pnlVerticalLineLeft_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDragSelect = 0;
        }

        private void pnlMid_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void pnlMid_DragDrop(object sender, DragEventArgs e)
        {
            if (mouseDragSelect == 1)
            {
                pnlVerticalLineLeft.Location = this.pnlMid.PointToClient(new Point(e.X, pnlMid.Location.Y));
                //this.panel1.Controls.Add(c);
                pnlVerticalLineLeft.Location = new Point(pnlVerticalLineLeft.Location.X, 0);
                int time = (int)waveStream.TotalTime.TotalMilliseconds * pnlVerticalLineLeft.Location.X / this.pnlMid.Width;
                string sTime = "";
                int min = time / (60 * 10000);
                time = time - min * 60 * 1000;
                if (min != 0)
                {
                    sTime += min.ToString() + ":";
                }
                int sec = time / 1000;
                time = time - sec * 1000;
                if (sec != 0)
                {
                    sTime += sec.ToString() + ":";
                }
                if (time != 0)
                {
                    time = time / 100;
                    sTime += time.ToString();
                }// seconds la tong giay
                lbLeftTime.Text = sTime;
                lbLeftTime.Location = new Point(pnlVerticalLineLeft.Location.X, 0);
            }
            else if(mouseDragSelect == 2)
            {
                pnlVerticalLineRight.Location = this.pnlMid.PointToClient(new Point(e.X, e.Y));
                pnlVerticalLineRight.Location = new Point(pnlVerticalLineRight.Location.X, 0);
                int time = (int)waveStream.TotalTime.TotalMilliseconds * pnlVerticalLineRight.Location.X / this.pnlMid.Width;
                string sTime = "";
                int min = time / (60 * 10000);
                time = time - min * 60 * 1000;
                if (min != 0)
                {
                    sTime += min.ToString() + ":";
                }
                int sec = time / 1000;
                time = time - sec * 1000;
                if (sec != 0)
                {
                    sTime += sec.ToString() + ":";
                }
                if (time != 0)
                {
                    time = time / 100;
                    sTime += time.ToString();
                }// seconds la tong giay
                lbRightTime.Text = sTime;
                lbRightTime.Location = new Point(pnlVerticalLineRight.Location.X, 0);
            }
        }


        public WaveFileReader Copy(out long leftPosition, out long rightPosition)
        {
            int leftSample = (int)(StartPosition / bytesPerSample + samplesPerPixel * pnlVerticalLineLeft.Location.X);
            int rightSample = (int)(StartPosition / bytesPerSample + samplesPerPixel * pnlVerticalLineRight.Location.X);
            leftPosition = leftSample * bytesPerSample;
            rightPosition = rightSample * bytesPerSample;
            return waveStream as WaveFileReader;
            //byte[] result = new byte[rightPosition - leftPosition];
            //waveStream.

        }

        public void FitToScreen()
        {
            if (waveStream == null) return;

            int samples = (int)(waveStream.Length / bytesPerSample);
            startPosition = 0;
            SamplesPerPixel = samples / this.pnlMid.Width;
            isChangedImage = true;
            Painting();
        }
        public void Play()
        {
            if (waveStream.Position < waveStream.Length)
            {
                timer1.Interval = 30;
                timer1.Start();
                isPlaying = true;
            }
        }
        public void Pause()
        {
            timer1.Stop();
        }
        public void Stop()
        {
            timer1.Stop();
            isPlaying = false;
        }
        public void Zoom(int leftSample, int rightSample)
        {
            startPosition = leftSample * bytesPerSample;
            SamplesPerPixel = (rightSample - leftSample) / this.Width;
            Painting();
        }
        
        public void Painting()
        {
            if (bmTemp == null || isChangedImage == true || isScroll == true)
            {
                bmTemp = new Bitmap(this.pnlMid.Width, this.pnlMid.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                waveStream.Position = 0;
                int bytesRead;
                //int samples = (int)(waveStream.Length / bytesPerSample);
                // samplesPerPixel = samples / (this.pnlMid.Width * this.hScrollBar1.Maximum / this.hScrollBar1.LargeChange);
                byte[] waveData = new byte[samplesPerPixel * bytesPerSample];
                waveStream.Position = startPosition + (0 * bytesPerSample * samplesPerPixel);
                Graphics g = Graphics.FromImage(bmTemp);
                //g.Clear(this.pnlMid.BackColor);
                using (Pen linePen = new Pen(PenColor, PenWidth))
                {
                    for (float x = 0; x < (this.pnlMid.Width - 1); x += 1)
                    {
                        short low = 0;
                        short high = 0;
                        bytesRead = waveStream.Read(waveData, 0, samplesPerPixel * bytesPerSample);
                        if (bytesRead == 0)
                            break;
                        for (int n = 0; n < bytesRead; n += 2)
                        {
                            short sample = BitConverter.ToInt16(waveData, n);
                            if (sample < low) low = sample;
                            if (sample > high) high = sample;
                        }
                        float lowPercent = ((((float)low) - short.MinValue) / ushort.MaxValue);
                        float highPercent = ((((float)high) - short.MinValue) / ushort.MaxValue);
                        g.DrawLine(linePen, x, this.pnlMid.Height * lowPercent, x, this.pnlMid.Height * highPercent);
                    }
                }
                isChangedImage = false;
                isScroll = false;
            }
            pnlMid.BackgroundImage = bmTemp;


        }
        private void setTextCurTime()
        {
            string curTime = "";
            if (waveStream.TotalTime.Minutes != 0)
            {
                curTime += waveStream.CurrentTime.Minutes.ToString() + ":";
            }
            if (waveStream.TotalTime.Seconds != 0)
            {
                curTime += waveStream.CurrentTime.Seconds.ToString() + ":";
            }
            if (waveStream.TotalTime.Milliseconds != 0)
            {
                int mili = 0;
                if (waveStream.CurrentTime.Milliseconds != 0) mili = waveStream.CurrentTime.Milliseconds / 100;
                curTime += mili.ToString();
            }// seconds la tong giay
            lbCurTime.Text = curTime;
        }

        
    }
}
