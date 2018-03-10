using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace PomodoroClock
{
    public partial class Form_main : Form
    {
        delegate void SetTextCallback(string text);
        delegate void SetVisibleCallback(bool visible);
        static int TIME_DURATION_WORK = 25 * 60 * 1000;//默认25分钟
        static int TIME_DURATION_REST = 5 * 60 * 1000;
        static int TIME_DURATION_NOW = 0;
        static int REST_COUNT = 0;
        static bool RESTING = false;//false=工作，true=休息
        static System.Timers.Timer SENCOND_CLOCK = new System.Timers.Timer();
        public Form_main()
        {
            InitializeComponent();
            textBox_timeDuration.Text = "45";
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            SetTimDurationEV(false);
            SENCOND_CLOCK.Interval = 1000;
            SENCOND_CLOCK.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerProcess);
            int result;
            int.TryParse(textBox_timeDuration.Text, out result);
            if (result != 0)
            {
                TIME_DURATION_WORK = result * 60 * 1000;
                TIME_DURATION_REST = (int)(TIME_DURATION_WORK * 0.3);
            }
            this.Hide();
        }
        private void TimerProcess(object sender, System.Timers.ElapsedEventArgs e)
        {

            //修改TIME_DURATION_NOW，并判断是否已到期限
            TIME_DURATION_NOW += 1000;
            ChangeVisibleTime();
            if (RESTING)
            {
                if (TIME_DURATION_NOW >= TIME_DURATION_REST)
                {
                    RESTING = !RESTING;
                    TIME_DURATION_NOW = 0;
                    SetFormVisible(false);
                    REST_COUNT++;
                    if (REST_COUNT == 4)
                    {
                        TIME_DURATION_REST *= 5;
                    }
                    else if (REST_COUNT > 4)
                    {
                        TIME_DURATION_REST /= 5;
                    }
                }
            }
            else
            {
                if (TIME_DURATION_NOW >= TIME_DURATION_WORK)
                {
                    RESTING = !RESTING;
                    TIME_DURATION_NOW = 0;
                    SetFormVisible(true);
                }
            }
        }
        private void SetFormVisible(bool b)
        {
            if (this.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(SetFormVisible);
                this.Invoke(d, new object[] { b });
            }
            else
            {
                this.Visible = b;
                if (b)
                {
                    this.Activate();
                }
            }
        }

        private void ChangeVisibleTime()
        {
            string timeString = GetTimeString();
            ThreadSetText(timeString);
        }
        private void ThreadSetText(string s)
        {
            if (this.leftTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ThreadSetText);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                this.leftTime.Text = s;
            }
        }

        private void Form_main_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true && !RESTING)
            {
                SENCOND_CLOCK.Stop();

            }
            else
            {
                SENCOND_CLOCK.Start();
            }
            Alert();
        }

        private void TextBox_timeDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制为数字
            if ((int)e.KeyChar < 48 || (int)e.KeyChar > 57 && (int)e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void NotifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.BalloonTipText =leftTime.Text;
                notifyIcon.BalloonTipTitle = (RESTING ? "REST" : "WORK") + " TIME LEFT";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox_timeDuration_Click(object sender, EventArgs e)
        {
            textBox_timeDuration.SelectAll();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }
        private void Alert()
        {
            SoundPlayer alertPlayer = new SoundPlayer();
            alertPlayer.SoundLocation = "AlertSound.wav";
            try
            {
                alertPlayer.Play();
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show("声音播放失败，请检查程序完整性", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(fnfe.Message);
            }
        }

        private void TerminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimDurationEV(true);
            TIME_DURATION_NOW = 0;
            ThreadSetText("00:00");
            SENCOND_CLOCK.Stop();
            this.Show();
            this.Activate();
        }
        private void SetTimDurationEV(bool enable)
        {
            label_timeDuration.Enabled = label_timeDuration.Visible = button_submit.Enabled = button_submit.Visible = textBox_timeDuration.Enabled = textBox_timeDuration.Visible = enable;
        }
        private string GetTimeString()
        {
            int tmpTime, second, minute;
            string secondS, minuteS;
            if (RESTING)
            {
                tmpTime = (TIME_DURATION_REST - TIME_DURATION_NOW) / 1000;
            }
            else
            {
                tmpTime = (TIME_DURATION_WORK - TIME_DURATION_NOW) / 1000;
            }
            minute = tmpTime / 60;
            second = tmpTime % 60;
            if (minute < 10)
            {
                minuteS = "0" + minute.ToString();
            }
            else
            {
                minuteS = minute.ToString();
            }
            if (second < 10)
            {
                secondS = "0" + second.ToString();
            }
            else
            {
                secondS = second.ToString();
            }
            string timeString = minuteS + ":" + secondS;
            return timeString;
        }
    }
}