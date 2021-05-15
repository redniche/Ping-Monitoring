using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Design;
namespace SurveilNetwork
{
    public partial class Surveil : Form
    {
        [DllImport("kernel32.dll")]
        extern public static void Beep(int freq, int dur);
        private BackgroundWorker[] worker;
        private System.Windows.Forms.Label[] labelHost;
        private TextBox MenterTB;
        private int xPos = 0;
        private int yPos = 0;
        private byte nStack = 0;
        public Surveil()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker tmpW = (BackgroundWorker)sender;
            Label tmpL = (Label)e.Argument;
            int sBeep = 0;
            while (!tmpW.CancellationPending)
            {
                if (labelHost.Length > 0)
                {
                    try
                    {
                        PingReply reply;
                        if (tmpW.CancellationPending)
                            return;
                        reply = Ping_Result(tmpL.Name);
                        if (tmpW.CancellationPending)
                            return;
                        if (reply != null && reply.Status == IPStatus.Success)
                        {
                            if (reply.RoundtripTime < 100)
                            {
                                tmpL.ForeColor = Color.Green;
                                sBeep = 0;
                            }
                            else if (reply.RoundtripTime < 200)
                            {
                                tmpL.ForeColor = Color.Orange;
                                sBeep = 0;
                            }
                            else
                            {
                                tmpL.ForeColor = Color.Red;
                                sBeep++;
                            }
                        }
                        else
                        {
                            tmpL.ForeColor = Color.BlueViolet;
                            sBeep++;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    if (sBeep > 60)
                    {
                        Thread beepW = new Thread(new ThreadStart(beep_Work));
                        beepW.IsBackground = true;
                        beepW.Start();
                        if (sBeep > 61) sBeep--;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        if (!tmpW.CancellationPending)
                            Thread.Sleep(100);
                        else
                            return;
                    }
                    if (!tmpW.CancellationPending)
                        GC.Collect();
                    else
                        return;
                }
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            labelCaption.Text = "관제중";
            textBox1.ReadOnly = true;
            textBoxS.ReadOnly = false;
            textBox1.PasswordChar = '*';
            try
            {
                string[] strArr = textBox1.Lines;
                string[] splArr = new string[2];
                //공백을 제외한 길이 변수
                int realSize = strArr.Length;
                foreach (string str in strArr)
                    if (string.IsNullOrEmpty(str))
                        realSize--;
                try
                {
                    if (realSize < labelHost.Length)
                        for (int i = realSize; i < labelHost.Length; i++)
                        {
                            Controls.Remove(labelHost[i]);
                            yPos--;
                        }
                }
                catch (NullReferenceException ex)
                {
                    GC.Collect();
                }
                Array.Resize(ref labelHost, realSize);
                int real_i = 0;
                for (int i = 0; i < strArr.Length; i++)
                {
                    xPos = 0;
                    yPos = 0;
                    if (!string.IsNullOrEmpty(strArr[i]))
                    {
                        if (labelHost[real_i] == null)
                        {
                            labelHost[real_i] = new Label();
                            labelHost[real_i].Paint += new System.Windows.Forms.PaintEventHandler(this.labelHost_Paint);
                            labelHost[real_i].Size = new System.Drawing.Size(80, 20);
                            Controls.Add(labelHost[real_i]);
                        }
                        if (i > 1)
                        {
                            for (int j = i; j > 0; j--)
                                if (!string.IsNullOrEmpty(strArr[j - 1]) && string.IsNullOrEmpty(strArr[j]))
                                {
                                    xPos++;
                                }
                        }
                        int ct = i - 1;
                        while (ct >= 0 && !string.IsNullOrEmpty(strArr[ct--]))
                        {
                            yPos++;
                        }
                        labelHost[real_i].Location = new System.Drawing.Point(300 + 80 * xPos, 10 + 20 * yPos);
                        //한글자라도 /나 tab이 있으면 ck를 false로 바꿈
                        bool ck = true;
                        foreach (char c in strArr[i])
                        {
                            if (c == '/' || c == '\t' && ck == true)
                            {
                                splArr = strArr[i].Split(new char[] { '/', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                                ck = false;
                                break;
                            }
                        }
                        if (ck && !labelHost[real_i].Name.Equals(strArr[i]) || strArr[i][0] == '\'')
                        {
                            labelHost[real_i].Name = strArr[i];
                            if (strArr[i][0] == '\'')
                                labelHost[real_i].Text = strArr[i];
                            else if (strArr[i].Length > 5)
                                labelHost[real_i].Text = "**.**" + strArr[i].Substring(5);
                            else
                                labelHost[real_i].Text = strArr[i];
                        }
                        else if (!ck && (!labelHost[real_i].Name.Equals(splArr[1]) || !labelHost[real_i].Text.Equals(splArr[0])))
                        {
                            labelHost[real_i].Name = splArr[1];
                            labelHost[real_i].Text = "●" + splArr[0];
                        }
                        real_i++;
                    }
                }
                Array.Resize(ref worker, realSize);
                for (int i = 0; i < realSize; i++)
                {
                    if (labelHost[i].Name[0] != '\'')
                    {
                        if (worker[i] == null)
                        {
                            worker[i] = new BackgroundWorker();
                            worker[i].WorkerSupportsCancellation = true;
                            worker[i].DoWork += new DoWorkEventHandler(worker_DoWork);
                        }
                        if (!worker[i].IsBusy)
                            worker[i].RunWorkerAsync(labelHost[i]);
                    }
                }
                GC.Collect();
            }
            catch (IndexOutOfRangeException ex)
            {
                GC.Collect();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (textBoxS.Text.Equals("dPcks3"))
            {
                if (labelHost != null)
                    foreach (Label l in labelHost)
                        if (l != null)
                            l.ForeColor = Color.Black;
                textBox1.ReadOnly = false;
                textBox1.PasswordChar = (char)0;
                textBox1.Focus();
                buttonStop.Enabled = false;
                nStack = 0;
                Thread stoptr = new Thread(new ThreadStart(stop_Work));
                stoptr.IsBackground = true;
                stoptr.Start();
                textBoxS.Text = "";
                textBoxS.ReadOnly = true;
            }
            else
            {
                nStack++;
                if (nStack == 3)
                    this.Dispose();
                MessageBox.Show(@"비밀번호가 틀립니다.
(3회 초과시 종료)");
                textBoxS.Text = "";
                textBoxS.Focus();
            }
            GC.Collect();
        }
        private void stop_Work()
        {
            bool conti = true;
            if (labelCaption.InvokeRequired)
            {
                labelCaption.BeginInvoke(new Action(() => labelCaption.Text = "관제 정지중"));
            }
            else
                labelCaption.Text = "관제 정지중";
            while (conti && worker != null)
            {
                conti = false;
                foreach (BackgroundWorker work in worker)
                {
                    if (work != null && work.IsBusy)
                    {
                        work.CancelAsync();
                        conti = true;
                    }
                }
                Thread.Sleep(100);
            }
            if (buttonStart.InvokeRequired)
            {
                buttonStart.BeginInvoke(new Action(() => buttonStart.Enabled = true));
            }
            else
                buttonStart.Enabled = true;
            if (labelCaption.InvokeRequired)
            {
                labelCaption.BeginInvoke(new Action(() => labelCaption.Text = "관제 정지완료"));
            }
            else
                labelCaption.Text = "관제 정지완료";
            GC.Collect();
        }
        private void beep_Work()
        {
            Beep(640, 2000);
        }
        private PingReply Ping_Result(string s)
        {
            Ping pingSender = new Ping();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 4000;
            PingOptions options = new PingOptions(255, true);
            try
            {
                PingReply reply = pingSender.Send(s, timeout, buffer, options);
                return reply;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void checkBoxS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxS.Checked == true)
                textBoxS.PasswordChar = (char)0;
            else
                textBoxS.PasswordChar = '*';
        }
        private void labelHost_Paint(object sender, PaintEventArgs e)
        {
            Label tmp_Lp = (Label)sender;
            if (tmp_Lp.ForeColor == Color.Green)
                ControlPaint.DrawBorder(e.Graphics, tmp_Lp.DisplayRectangle, Color.Green, ButtonBorderStyle.Solid);
            else if (tmp_Lp.ForeColor == Color.Orange)
                ControlPaint.DrawBorder(e.Graphics, tmp_Lp.DisplayRectangle, Color.Orange, ButtonBorderStyle.Solid);
            else if (tmp_Lp.ForeColor == Color.Red)
                ControlPaint.DrawBorder(e.Graphics, tmp_Lp.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
            else if (tmp_Lp.ForeColor == Color.BlueViolet)
                ControlPaint.DrawBorder(e.Graphics, tmp_Lp.DisplayRectangle, Color.BlueViolet, ButtonBorderStyle.Solid);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value * 0.1;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value * 0.1;
        }
    }
}
