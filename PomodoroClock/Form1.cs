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
            textBox_timeDuration.Text = "25";
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            label_timeDuration.Enabled = label_timeDuration.Visible = button_submit.Enabled = button_submit.Visible = textBox_timeDuration.Enabled = textBox_timeDuration.Visible = false;
            SENCOND_CLOCK.Interval = 1000;
            SENCOND_CLOCK.Elapsed += new System.Timers.ElapsedEventHandler(this.timerProcess);
            int result;
            int.TryParse(textBox_timeDuration.Text, out result);
            if (result != 0)
            {
                TIME_DURATION_WORK = result * 60 * 1000;
            }
            this.Hide();
        }
        private void timerProcess(object sender, System.Timers.ElapsedEventArgs e)
        {

            //修改TIME_DURATION_NOW，并判断是否已到期限
            TIME_DURATION_NOW += 1000;
            if (RESTING)
            {
                threadSetText("REST");
                if (TIME_DURATION_NOW >= TIME_DURATION_REST)
                {
                    TIME_DURATION_NOW = 0;
                    alert();
                    this.Visible = false;
                    REST_COUNT++;
                    if (REST_COUNT == 4)
                    {
                        TIME_DURATION_REST *= 5;
                    }
                    else if (TIME_DURATION_REST > 4)
                    {
                        TIME_DURATION_REST /= 5;
                    }
                    RESTING = !RESTING;
                }
            }
            else
            {
                changeVisibleTime();
                if (TIME_DURATION_NOW >= TIME_DURATION_WORK)
                {
                    TIME_DURATION_NOW = 0;
                    this.setFormVisible(true);
                    alert();
                    RESTING = !RESTING;
                }
            }
        }
        private void setFormVisible(bool b)
        {
            if (this.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(setFormVisible);
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

        private void changeVisibleTime()
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
            threadSetText(minuteS + ":" + secondS);
        }
        private void threadSetText(string s)
        {
            if (this.restTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(threadSetText);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                this.restTime.Text = s;
            }
            notifyIcon.BalloonTipText = restTime.Text;
        }

        private void Form_main_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (!RESTING)
                {
                    SENCOND_CLOCK.Stop();
                }
            }
            else
            {
                SENCOND_CLOCK.Start();
            }
        }

        private void textBox_timeDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制为数字
            if ((int)e.KeyChar < 48 || (int)e.KeyChar > 57 && (int)e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_timeDuration_Click(object sender, EventArgs e)
        {
            textBox_timeDuration.SelectAll();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }
        private void alert()
        {
            SoundPlayer alertPlayer = new SoundPlayer();
            alertPlayer.SoundLocation = "AlertSound.wav";
            try
            {
                alertPlayer.Play();
            }catch(FileNotFoundException fnfe)
            {
                MessageBox.Show("声音播放失败，请检查程序完整性", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(fnfe.Message);
            }
        }
    }
}