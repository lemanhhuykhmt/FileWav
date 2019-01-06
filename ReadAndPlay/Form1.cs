using NAudio.Wave;
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
using NAudio.Gui;

namespace ReadAndPlay
{
    public partial class Form1 : Form
    {
        private WaveFileReader wave = null;
        private DirectSoundOut output = null;
        private WaveChannel32 channel = null;
        private int selectedWave = 1;
        private WaveFileReader waveCopy = null;
        private long leftCopy, rightCopy;
        private string fileName1 = "";
        private string fileName2 = "";
        private bool isCut = false;
        private DEFINE.STATUS status = DEFINE.STATUS.STOP;
        public WaveFileReader Wave
        {
            set
            {
                wave = value;
                if (wave != null)
                {
                    channel = new WaveChannel32(wave);
                    showFormat();
                }
            }
            get
            {
                return wave;
            }
        }
        public Form1()
        {
            InitializeComponent();
            output = new DirectSoundOut();

        }
        private void showFormat()
        {
            if(wave != null)
            {
                lbTanSo.Text = wave.WaveFormat.SampleRate + "Hz";
                lbChieuSau.Text = wave.WaveFormat.BitsPerSample + "bit";
                lbLoaiKenh.Text = wave.WaveFormat.Channels == 1 ? "Mono" : "Stereo";
                lbKichThuoc.Text = wave.WaveFormat.Channels * wave.WaveFormat.BitsPerSample / 8 + "byte";
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav";
            if (open.ShowDialog() != DialogResult.OK) return;
            Wave = new WaveFileReader(open.FileName);
            if (selectedWave == 1)
            {
                fileName1 = open.FileName;
                cwvNumber1.WaveStream = wave;
                cwvNumber1.Painting();
                cwvNumber1.FitToScreen();
                cwvNumber1.WaveStream.Position = 0;
                cwvNumber1.Focus();
            }
            else if (selectedWave == 2)
            {
                fileName2 = open.FileName;
                cwvNumber2.WaveStream = wave;
                cwvNumber2.Painting();
                cwvNumber2.FitToScreen();
                cwvNumber2.WaveStream.Position = 0;
                cwvNumber2.Focus();
            }
            lbMax.Text = wave.TotalTime.Minutes.ToString() + ":" + wave.TotalTime.Seconds.ToString();
            lbCur.Text = "0 : 0";
            status = DEFINE.STATUS.READY;
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (status == DEFINE.STATUS.READY)
            {
                status = DEFINE.STATUS.RUNNING;
                output.Init(channel);
                output.Play();
                if (selectedWave == 1)
                {
                    cwvNumber1.Play();
                    cwvNumber1.Focus();
                }
                else if (selectedWave == 2)
                {
                    cwvNumber2.Play();
                    cwvNumber2.Focus();
                }
                timer1.Interval = 100;
                timer1.Start();
            }
            else if(status == DEFINE.STATUS.RUNNING)
            {
                status = DEFINE.STATUS.PAUSE;
                output.Pause();
                if (selectedWave == 1)
                {
                    cwvNumber1.Pause();
                }
                else if (selectedWave == 2)
                {
                    cwvNumber2.Pause();
                }
            }
            else if(status == DEFINE.STATUS.PAUSE)
            {
                status = DEFINE.STATUS.RUNNING;
                output.Play();
                if (selectedWave == 1)
                {
                    cwvNumber1.Play();
                }
                else if (selectedWave == 2)
                {
                    cwvNumber2.Play();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (output.PlaybackState == PlaybackState.Playing)
            {
                if (channel.Position > channel.Length)
                {
                    status = DEFINE.STATUS.READY;
                    channel.Position = 0;
                    output.Stop();
                    output.Init(channel);
                    if (selectedWave == 1)
                    {
                        cwvNumber1.WaveStream.Position = 0;
                    }
                    else if (selectedWave == 2)
                    {
                        cwvNumber2.WaveStream.Position = 0;
                    }
                }
                lbCur.Text = wave.CurrentTime.Minutes.ToString() + ":" + wave.CurrentTime.Seconds.ToString();
            }
        }

        private void ConvertWavTo10SecondWavs(FileInfo inputFile)
        {
            var samplesOutWav = @"..\..\..\samples\wav10seconds\";
            using (var inAudio = new WaveFileReader(inputFile.FullName))
            {
                //Calculate required byte[] buffer.
                var buffer = new byte[10 * inAudio.WaveFormat.AverageBytesPerSecond];//Assume average will be constant for WAV format.
                int index = 0;
                do
                {
                    var outFile = string.Format("{0}{1}.{2:0000}.wav",
                    samplesOutWav, inputFile.Name.Replace(inputFile.Extension, string.Empty), index);
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = inAudio.Read(buffer, 0, buffer.Length - bytesRead);
                    } while (bytesRead > 0 && bytesRead < buffer.Length);
                    //Write new file
                    using (var waveWriter = new WaveFileWriter(outFile, inAudio.WaveFormat))
                    {
                        waveWriter.Write(buffer, 0, buffer.Length);
                    }
                    index++;
                } while (inAudio.Position < inAudio.Length);
            }
        }

        private void cmsiSelect_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenuStrip = i.Owner as ContextMenuStrip;
            if (contextMenuStrip.SourceControl.Equals(cwvNumber1))
            {
                selectedWave = 1;
                Wave = cwvNumber1.WaveStream as WaveFileReader;
            }
            else if (contextMenuStrip.SourceControl.Equals(cwvNumber2))
            {
                selectedWave = 2;
                Wave = cwvNumber2.WaveStream as WaveFileReader;
            }
        }

        private void cmsiCopy_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenuStrip = i.Owner as ContextMenuStrip;
            if (contextMenuStrip.SourceControl.Equals(cwvNumber1))
            {
                waveCopy = cwvNumber1.Copy(out leftCopy, out rightCopy);
            }
            else if (contextMenuStrip.SourceControl.Equals(cwvNumber2))
            {
                waveCopy = cwvNumber2.Copy(out leftCopy, out rightCopy);
            }
        }

        private void cmsiCut_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenuStrip = i.Owner as ContextMenuStrip;
            if (contextMenuStrip.SourceControl.Equals(cwvNumber1))
            {
                waveCopy = cwvNumber1.Copy(out leftCopy, out rightCopy);
                isCut = true;
            }
            else if (contextMenuStrip.SourceControl.Equals(cwvNumber2))
            {
                waveCopy = cwvNumber2.Copy(out leftCopy, out rightCopy);
                isCut = true;
            }
        }

        private void cmsiPaste_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenuStrip = i.Owner as ContextMenuStrip;
            if (contextMenuStrip.SourceControl.Equals(cwvNumber1))
            {

                ConCatWaveFile(waveCopy, cwvNumber1.WaveStream as WaveFileReader, leftCopy, rightCopy);
                if(isCut)
                {
                    DeleteWaveFile(waveCopy, leftCopy, rightCopy);
                    isCut = false;
                }
            }
            else if (contextMenuStrip.SourceControl.Equals(cwvNumber2))
            {
                ConCatWaveFile(waveCopy, cwvNumber2.WaveStream as WaveFileReader, leftCopy, rightCopy);
                if (isCut)
                {
                    DeleteWaveFile(waveCopy, leftCopy, rightCopy);
                    isCut = false;
                }
            }
        }

        private void cwvNumber1_Click(object sender, EventArgs e)
        {
            selectedWave = 1;
            Wave = cwvNumber1.WaveStream as WaveFileReader;
        }

        private void cwvNumber2_Click(object sender, EventArgs e)
        {
            selectedWave = 2;
            Wave = cwvNumber2.WaveStream as WaveFileReader;
        }

        private void ConCatWaveFile(WaveFileReader sou, WaveFileReader des, long startPos, long endPos)
        {
            // lưu toàn bộ file đích vào temp
            WaveFileWriter temp = new WaveFileWriter("temp.wav", des.WaveFormat);
            // des.Filename = "";
            des.Position = 0;
            var end = (int)des.Length;
            var buffer = new byte[1024];
            while (des.Position < end)
            {
                var bytesRequired = (int)(end - des.Position);
                if (bytesRequired <= 0) continue;
                var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                var bytesRead = des.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0)
                {
                    temp.Write(buffer, 0, bytesRead);
                }
            }

            // lưu 1 phần thêm file nguồn vào temp
            sou.Position = startPos;
            buffer = new byte[1024];
            while (sou.Position < endPos)
            {
                int bytesRequired = (int)(endPos - sou.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = sou.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        temp.Write(buffer, 0, bytesRead);
                    }
                }
            }
            temp.Dispose();
            des.Dispose();
            // xoá file đích
            if (des.Equals(cwvNumber1.WaveStream))
            {
                CopyWaveFile(fileName1, temp.Filename);
                Wave = new WaveFileReader(fileName1);

                cwvNumber1.WaveStream = wave;
                cwvNumber1.Painting();
                cwvNumber1.FitToScreen();
                cwvNumber1.WaveStream.Position = 0;


                lbMax.Text = wave.TotalTime.Minutes.ToString() + ":" + wave.TotalTime.Seconds.ToString();
                lbCur.Text = "0 : 0";
            }
            else if (des.Equals(cwvNumber2.WaveStream))
            {
                CopyWaveFile(fileName2, temp.Filename);
                Wave = new WaveFileReader(fileName2);

                cwvNumber2.WaveStream = wave;
                cwvNumber2.Painting();
                cwvNumber2.FitToScreen();
                cwvNumber2.WaveStream.Position = 0;

                lbMax.Text = wave.TotalTime.Minutes.ToString() + ":" + wave.TotalTime.Seconds.ToString();
                lbCur.Text = "0 : 0";
            }
        }

        private void DeleteWaveFile(WaveFileReader sou, long startPos, long endPos)
        {
            // tạo file temp 
            WaveFileWriter temp = new WaveFileWriter("temp.wav", sou.WaveFormat);
            sou.Position = 0;
            var buffer = new byte[1024];
            // lưu từ đầu đến star
            while (sou.Position < startPos)
            {
                var bytesRequired = (int)(startPos - sou.Position);
                if (bytesRequired <= 0) continue;
                var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                var bytesRead = sou.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0)
                {
                    temp.Write(buffer, 0, bytesRead);
                }
            }
            // lưu tiêp từ end đên hết
            sou.Position = endPos;
            while (sou.Position < sou.Length)
            {
                var bytesRequired = (int)(sou.Length - sou.Position);
                if (bytesRequired <= 0) continue;
                var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                var bytesRead = sou.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0)
                {
                    temp.Write(buffer, 0, bytesRead);
                }
            }
            // ghi đè lại sou
            temp.Dispose();
            sou.Dispose();
            if (sou.Equals(cwvNumber1.WaveStream))
            {
                CopyWaveFile(fileName1, temp.Filename);
                Wave = new WaveFileReader(fileName1);

                cwvNumber1.WaveStream = wave;
                cwvNumber1.Painting();
                cwvNumber1.FitToScreen();
                cwvNumber1.WaveStream.Position = 0;


                lbMax.Text = wave.TotalTime.Minutes.ToString() + ":" + wave.TotalTime.Seconds.ToString();
                lbCur.Text = "0 : 0";
            }
            else if (sou.Equals(cwvNumber2.WaveStream))
            {
                CopyWaveFile(fileName2, temp.Filename);
                Wave = new WaveFileReader(fileName2);

                cwvNumber2.WaveStream = wave;
                cwvNumber2.Painting();
                cwvNumber2.FitToScreen();
                cwvNumber2.WaveStream.Position = 0;

                lbMax.Text = wave.TotalTime.Minutes.ToString() + ":" + wave.TotalTime.Seconds.ToString();
                lbCur.Text = "0 : 0";
            }
        }

        private void CopyWaveFile(string destinationFile, string sourceFile)
        {
            using (var fs = File.Open(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new WaveFileReader(fs))
                {
                    using (var writer = new WaveFileWriter(destinationFile, reader.WaveFormat))
                    {
                        reader.Position = 0;
                        var endPos = (int)reader.Length;
                        var buffer = new byte[1024];
                        while (reader.Position < endPos)
                        {
                            var bytesRequired = (int)(endPos - reader.Position);
                            if (bytesRequired <= 0) continue;
                            var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                            var bytesRead = reader.Read(buffer, 0, bytesToRead);
                            if (bytesRead > 0)
                            {
                                writer.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
        }
    }

}
