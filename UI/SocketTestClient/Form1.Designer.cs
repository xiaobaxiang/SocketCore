namespace SocketTestClient
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnUploadState = new System.Windows.Forms.Button();
            this.btnUserLogin = new System.Windows.Forms.Button();
            this.btnAddLight = new System.Windows.Forms.Button();
            this.btnQryDeviceState = new System.Windows.Forms.Button();
            this.btnSendWaring = new System.Windows.Forms.Button();
            this.btnRemoveLight = new System.Windows.Forms.Button();
            this.btnSetTem = new System.Windows.Forms.Button();
            this.btnSetWet = new System.Windows.Forms.Button();
            this.btnSetTemRange = new System.Windows.Forms.Button();
            this.btnSetWetRange = new System.Windows.Forms.Button();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.lsbSearchRes = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chxSendMsg = new System.Windows.Forms.CheckBox();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStage = new System.Windows.Forms.Button();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.btnSetUploadTimeSpan = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(770, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 465);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(761, 150);
            this.txtMsg.TabIndex = 1;
            // 
            // lstMsg
            // 
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.ItemHeight = 12;
            this.lstMsg.Location = new System.Drawing.Point(6, 5);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(855, 352);
            this.lstMsg.TabIndex = 2;
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(6, 373);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 3;
            this.btnExcute.Text = "设备注册";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(87, 373);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "设备登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnUploadState
            // 
            this.btnUploadState.Location = new System.Drawing.Point(168, 373);
            this.btnUploadState.Name = "btnUploadState";
            this.btnUploadState.Size = new System.Drawing.Size(75, 23);
            this.btnUploadState.TabIndex = 3;
            this.btnUploadState.Text = "上报状态";
            this.btnUploadState.UseVisualStyleBackColor = true;
            this.btnUploadState.Click += new System.EventHandler(this.btnUploadState_Click);
            // 
            // btnUserLogin
            // 
            this.btnUserLogin.Location = new System.Drawing.Point(89, 402);
            this.btnUserLogin.Name = "btnUserLogin";
            this.btnUserLogin.Size = new System.Drawing.Size(75, 23);
            this.btnUserLogin.TabIndex = 3;
            this.btnUserLogin.Text = "用户登录";
            this.btnUserLogin.UseVisualStyleBackColor = true;
            this.btnUserLogin.Click += new System.EventHandler(this.btnUserLogin_Click);
            // 
            // btnAddLight
            // 
            this.btnAddLight.Location = new System.Drawing.Point(330, 402);
            this.btnAddLight.Name = "btnAddLight";
            this.btnAddLight.Size = new System.Drawing.Size(75, 23);
            this.btnAddLight.TabIndex = 3;
            this.btnAddLight.Text = "添加灯";
            this.btnAddLight.UseVisualStyleBackColor = true;
            this.btnAddLight.Click += new System.EventHandler(this.btnBhOpenLock_Click);
            // 
            // btnQryDeviceState
            // 
            this.btnQryDeviceState.Location = new System.Drawing.Point(170, 402);
            this.btnQryDeviceState.Name = "btnQryDeviceState";
            this.btnQryDeviceState.Size = new System.Drawing.Size(75, 23);
            this.btnQryDeviceState.TabIndex = 3;
            this.btnQryDeviceState.Text = "查询设备状态";
            this.btnQryDeviceState.UseVisualStyleBackColor = true;
            this.btnQryDeviceState.Click += new System.EventHandler(this.btnQryDeviceState_Click);
            // 
            // btnSendWaring
            // 
            this.btnSendWaring.Location = new System.Drawing.Point(249, 373);
            this.btnSendWaring.Name = "btnSendWaring";
            this.btnSendWaring.Size = new System.Drawing.Size(75, 23);
            this.btnSendWaring.TabIndex = 3;
            this.btnSendWaring.Text = "发送警报";
            this.btnSendWaring.UseVisualStyleBackColor = true;
            this.btnSendWaring.Click += new System.EventHandler(this.btnSendWaring_Click);
            // 
            // btnRemoveLight
            // 
            this.btnRemoveLight.Location = new System.Drawing.Point(411, 402);
            this.btnRemoveLight.Name = "btnRemoveLight";
            this.btnRemoveLight.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLight.TabIndex = 3;
            this.btnRemoveLight.Text = "删除灯";
            this.btnRemoveLight.UseVisualStyleBackColor = true;
            this.btnRemoveLight.Click += new System.EventHandler(this.btnFullProduct_Click);
            // 
            // btnSetTem
            // 
            this.btnSetTem.Location = new System.Drawing.Point(249, 431);
            this.btnSetTem.Name = "btnSetTem";
            this.btnSetTem.Size = new System.Drawing.Size(75, 23);
            this.btnSetTem.TabIndex = 3;
            this.btnSetTem.Text = "路灯开关";
            this.btnSetTem.UseVisualStyleBackColor = true;
            this.btnSetTem.Click += new System.EventHandler(this.btnSetTem_Click);
            // 
            // btnSetWet
            // 
            this.btnSetWet.Location = new System.Drawing.Point(330, 431);
            this.btnSetWet.Name = "btnSetWet";
            this.btnSetWet.Size = new System.Drawing.Size(75, 23);
            this.btnSetWet.TabIndex = 3;
            this.btnSetWet.Text = "路灯功率";
            this.btnSetWet.UseVisualStyleBackColor = true;
            this.btnSetWet.Click += new System.EventHandler(this.btnSetWet_Click);
            // 
            // btnSetTemRange
            // 
            this.btnSetTemRange.Location = new System.Drawing.Point(412, 431);
            this.btnSetTemRange.Name = "btnSetTemRange";
            this.btnSetTemRange.Size = new System.Drawing.Size(74, 23);
            this.btnSetTemRange.TabIndex = 3;
            this.btnSetTemRange.Text = "路灯电压";
            this.btnSetTemRange.UseVisualStyleBackColor = true;
            this.btnSetTemRange.Click += new System.EventHandler(this.btnSetTemRange_Click);
            // 
            // btnSetWetRange
            // 
            this.btnSetWetRange.Location = new System.Drawing.Point(492, 431);
            this.btnSetWetRange.Name = "btnSetWetRange";
            this.btnSetWetRange.Size = new System.Drawing.Size(73, 23);
            this.btnSetWetRange.TabIndex = 3;
            this.btnSetWetRange.Text = "路灯温度";
            this.btnSetWetRange.UseVisualStyleBackColor = true;
            this.btnSetWetRange.Click += new System.EventHandler(this.btnSetWetRange_Click);
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(6, 21);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(839, 21);
            this.txbSearch.TabIndex = 4;
            this.txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSearch_KeyDown);
            // 
            // lsbSearchRes
            // 
            this.lsbSearchRes.FormattingEnabled = true;
            this.lsbSearchRes.ItemHeight = 12;
            this.lsbSearchRes.Location = new System.Drawing.Point(6, 58);
            this.lsbSearchRes.Name = "lsbSearchRes";
            this.lsbSearchRes.Size = new System.Drawing.Size(839, 556);
            this.lsbSearchRes.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 644);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chxSendMsg);
            this.tabPage1.Controls.Add(this.lstMsg);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnSendWaring);
            this.tabPage1.Controls.Add(this.txtMsg);
            this.tabPage1.Controls.Add(this.btnSetDefault);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.btnStage);
            this.tabPage1.Controls.Add(this.btnSetWetRange);
            this.tabPage1.Controls.Add(this.btnUploadState);
            this.tabPage1.Controls.Add(this.btnSetWet);
            this.tabPage1.Controls.Add(this.btnExcute);
            this.tabPage1.Controls.Add(this.btnSetTemRange);
            this.tabPage1.Controls.Add(this.btnLogin);
            this.tabPage1.Controls.Add(this.btnOpenDevice);
            this.tabPage1.Controls.Add(this.btnSetTem);
            this.tabPage1.Controls.Add(this.btnUserLogin);
            this.tabPage1.Controls.Add(this.btnRemoveLight);
            this.tabPage1.Controls.Add(this.btnAddLight);
            this.tabPage1.Controls.Add(this.btnSetUploadTimeSpan);
            this.tabPage1.Controls.Add(this.btnQryDeviceState);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(867, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制/输出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chxSendMsg
            // 
            this.chxSendMsg.AutoSize = true;
            this.chxSendMsg.Checked = true;
            this.chxSendMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxSendMsg.Location = new System.Drawing.Point(770, 567);
            this.chxSendMsg.Name = "chxSendMsg";
            this.chxSendMsg.Size = new System.Drawing.Size(96, 16);
            this.chxSendMsg.TabIndex = 4;
            this.chxSendMsg.Text = "发送文本消息";
            this.chxSendMsg.UseVisualStyleBackColor = true;
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Location = new System.Drawing.Point(729, 431);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(73, 23);
            this.btnSetDefault.TabIndex = 3;
            this.btnSetDefault.Text = "默认功率";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(650, 431);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "中继重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStage
            // 
            this.btnStage.Location = new System.Drawing.Point(571, 431);
            this.btnStage.Name = "btnStage";
            this.btnStage.Size = new System.Drawing.Size(73, 23);
            this.btnStage.TabIndex = 3;
            this.btnStage.Text = "阶段点功率";
            this.btnStage.UseVisualStyleBackColor = true;
            this.btnStage.Click += new System.EventHandler(this.btnStage_Click);
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(168, 431);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDevice.TabIndex = 3;
            this.btnOpenDevice.Text = "中继开关";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // btnSetUploadTimeSpan
            // 
            this.btnSetUploadTimeSpan.Location = new System.Drawing.Point(249, 402);
            this.btnSetUploadTimeSpan.Name = "btnSetUploadTimeSpan";
            this.btnSetUploadTimeSpan.Size = new System.Drawing.Size(75, 23);
            this.btnSetUploadTimeSpan.TabIndex = 3;
            this.btnSetUploadTimeSpan.Text = "上报时间";
            this.btnSetUploadTimeSpan.UseVisualStyleBackColor = true;
            this.btnSetUploadTimeSpan.Click += new System.EventHandler(this.btnSetUploadTimeSpan_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txbSearch);
            this.tabPage2.Controls.Add(this.lsbSearchRes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 668);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "客户端";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnUploadState;
        private System.Windows.Forms.Button btnUserLogin;
        private System.Windows.Forms.Button btnAddLight;
        private System.Windows.Forms.Button btnQryDeviceState;
        private System.Windows.Forms.Button btnSendWaring;
        private System.Windows.Forms.Button btnRemoveLight;
        private System.Windows.Forms.Button btnSetTem;
        private System.Windows.Forms.Button btnSetWet;
        private System.Windows.Forms.Button btnSetTemRange;
        private System.Windows.Forms.Button btnSetWetRange;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.ListBox lsbSearchRes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chxSendMsg;
        private System.Windows.Forms.Button btnSetUploadTimeSpan;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button btnStage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSetDefault;
    }
}

