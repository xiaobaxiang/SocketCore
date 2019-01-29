namespace SocketTestServer
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
            this.btnSend = new System.Windows.Forms.Button();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lstClient = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.lsbSearchRes = new System.Windows.Forms.ListBox();
            this.chxIsMsg = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1126, 715);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(64, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstMsg
            // 
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.ItemHeight = 12;
            this.lstMsg.Location = new System.Drawing.Point(6, 6);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(1114, 568);
            this.lstMsg.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 585);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(1114, 150);
            this.txtMsg.TabIndex = 2;
            // 
            // lstClient
            // 
            this.lstClient.FormattingEnabled = true;
            this.lstClient.ItemHeight = 12;
            this.lstClient.Location = new System.Drawing.Point(1126, 6);
            this.lstClient.Name = "lstClient";
            this.lstClient.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstClient.Size = new System.Drawing.Size(211, 688);
            this.lstClient.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1351, 767);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chxIsMsg);
            this.tabPage1.Controls.Add(this.lstMsg);
            this.tabPage1.Controls.Add(this.txtMsg);
            this.tabPage1.Controls.Add(this.lstClient);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1343, 741);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制/输出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txbSearch);
            this.tabPage2.Controls.Add(this.lsbSearchRes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1343, 741);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(6, 6);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(1331, 21);
            this.txbSearch.TabIndex = 6;
            this.txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSearch_KeyDown);
            // 
            // lsbSearchRes
            // 
            this.lsbSearchRes.FormattingEnabled = true;
            this.lsbSearchRes.ItemHeight = 12;
            this.lsbSearchRes.Location = new System.Drawing.Point(6, 43);
            this.lsbSearchRes.Name = "lsbSearchRes";
            this.lsbSearchRes.Size = new System.Drawing.Size(1331, 688);
            this.lsbSearchRes.TabIndex = 5;
            // 
            // chxIsMsg
            // 
            this.chxIsMsg.AutoSize = true;
            this.chxIsMsg.Checked = true;
            this.chxIsMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxIsMsg.Location = new System.Drawing.Point(1126, 700);
            this.chxIsMsg.Name = "chxIsMsg";
            this.chxIsMsg.Size = new System.Drawing.Size(108, 16);
            this.chxIsMsg.TabIndex = 4;
            this.chxIsMsg.Text = "发送纯文本消息";
            this.chxIsMsg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 791);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "上位机";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ListBox lstClient;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.ListBox lsbSearchRes;
        private System.Windows.Forms.CheckBox chxIsMsg;
    }
}

