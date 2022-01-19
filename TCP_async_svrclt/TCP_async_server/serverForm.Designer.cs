namespace TCP_async_server
{
    partial class serverForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSvrPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSvrIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSvrOpen = new System.Windows.Forms.Button();
            this.txtChatList = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ClientList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Connection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSvrPort
            // 
            this.txtSvrPort.Location = new System.Drawing.Point(289, 8);
            this.txtSvrPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtSvrPort.Name = "txtSvrPort";
            this.txtSvrPort.Size = new System.Drawing.Size(152, 21);
            this.txtSvrPort.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port Num";
            // 
            // txtSvrIP
            // 
            this.txtSvrIP.Location = new System.Drawing.Point(71, 8);
            this.txtSvrIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSvrIP.Name = "txtSvrIP";
            this.txtSvrIP.Size = new System.Drawing.Size(152, 21);
            this.txtSvrIP.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server IP";
            // 
            // btnSvrOpen
            // 
            this.btnSvrOpen.Location = new System.Drawing.Point(457, 8);
            this.btnSvrOpen.Name = "btnSvrOpen";
            this.btnSvrOpen.Size = new System.Drawing.Size(116, 21);
            this.btnSvrOpen.TabIndex = 16;
            this.btnSvrOpen.Text = "Server Open";
            this.btnSvrOpen.UseVisualStyleBackColor = true;
            this.btnSvrOpen.Click += new System.EventHandler(this.btnSvrOpen_Click);
            // 
            // txtChatList
            // 
            this.txtChatList.BackColor = System.Drawing.SystemColors.Window;
            this.txtChatList.Location = new System.Drawing.Point(14, 37);
            this.txtChatList.Multiline = true;
            this.txtChatList.Name = "txtChatList";
            this.txtChatList.ReadOnly = true;
            this.txtChatList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatList.Size = new System.Drawing.Size(559, 503);
            this.txtChatList.TabIndex = 49;
            this.txtChatList.Text = "[Chat List]";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(14, 546);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(450, 54);
            this.txtMsg.TabIndex = 51;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(469, 546);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(104, 54);
            this.btnSend.TabIndex = 50;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // ClientList
            // 
            this.ClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.IP,
            this.Connection});
            this.ClientList.HideSelection = false;
            this.ClientList.Location = new System.Drawing.Point(583, 37);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(244, 562);
            this.ClientList.TabIndex = 52;
            this.ClientList.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "[Client List]";
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 608);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChatList);
            this.Controls.Add(this.btnSvrOpen);
            this.Controls.Add(this.txtSvrPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSvrIP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "serverForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSvrPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSvrIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSvrOpen;
        private System.Windows.Forms.TextBox txtChatList;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView ClientList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Connection;
        private System.Windows.Forms.Label label3;
    }
}

