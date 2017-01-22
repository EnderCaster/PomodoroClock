namespace PomodoroClock
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_exit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_timeDuration = new System.Windows.Forms.TextBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.label_timeDuration = new System.Windows.Forms.Label();
            this.restTime = new System.Windows.Forms.Label();
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_exit.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "时间剩余：";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip_exit;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PomodoroClock";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            // 
            // contextMenuStrip_exit
            // 
            this.contextMenuStrip_exit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem,
            this.terminateToolStripMenuItem});
            this.contextMenuStrip_exit.Name = "contextMenuStrip_exit";
            this.contextMenuStrip_exit.Size = new System.Drawing.Size(153, 70);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitToolStripMenuItem.Text = "Stop & Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // textBox_timeDuration
            // 
            this.textBox_timeDuration.Location = new System.Drawing.Point(36, 175);
            this.textBox_timeDuration.Name = "textBox_timeDuration";
            this.textBox_timeDuration.Size = new System.Drawing.Size(100, 21);
            this.textBox_timeDuration.TabIndex = 0;
            this.textBox_timeDuration.Click += new System.EventHandler(this.textBox_timeDuration_Click);
            this.textBox_timeDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_timeDuration_KeyPress);
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(142, 175);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(75, 23);
            this.button_submit.TabIndex = 2;
            this.button_submit.Text = "确认";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label_timeDuration
            // 
            this.label_timeDuration.AutoSize = true;
            this.label_timeDuration.Location = new System.Drawing.Point(36, 157);
            this.label_timeDuration.Name = "label_timeDuration";
            this.label_timeDuration.Size = new System.Drawing.Size(173, 12);
            this.label_timeDuration.TabIndex = 3;
            this.label_timeDuration.Text = "请输入每段工作时间的时长(分)";
            // 
            // restTime
            // 
            this.restTime.AutoSize = true;
            this.restTime.Font = new System.Drawing.Font("宋体", 50F);
            this.restTime.Location = new System.Drawing.Point(26, 48);
            this.restTime.Name = "restTime";
            this.restTime.Size = new System.Drawing.Size(199, 67);
            this.restTime.TabIndex = 4;
            this.restTime.Text = "00:00";
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.terminateToolStripMenuItem.Text = "terminate";
            this.terminateToolStripMenuItem.Click += new System.EventHandler(this.terminateToolStripMenuItem_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 226);
            this.Controls.Add(this.restTime);
            this.Controls.Add(this.label_timeDuration);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.textBox_timeDuration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_main";
            this.Text = "Timer for Pomodoro Technique";
            this.VisibleChanged += new System.EventHandler(this.Form_main_VisibleChanged);
            this.contextMenuStrip_exit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox textBox_timeDuration;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label_timeDuration;
        private System.Windows.Forms.Label restTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_exit;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
    }
}

