namespace TCP_async_client
{
    partial class clientForm
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtCliID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSvrIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChatList = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ClientList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(136, 109);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 12);
            this.linkLabel1.TabIndex = 22;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(248, -20);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(0, 12);
            this.linkLabel2.TabIndex = 27;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(683, 9);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(102, 21);
            this.btnConnect.TabIndex = 39;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // txtCliID
            // 
            this.txtCliID.Location = new System.Drawing.Point(518, 9);
            this.txtCliID.Margin = new System.Windows.Forms.Padding(2);
            this.txtCliID.Name = "txtCliID";
            this.txtCliID.Size = new System.Drawing.Size(152, 21);
            this.txtCliID.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(462, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "Client ID";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(295, 9);
            this.txtPortNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(152, 21);
            this.txtPortNum.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "Port Num";
            // 
            // txtSvrIP
            // 
            this.txtSvrIP.Location = new System.Drawing.Point(68, 8);
            this.txtSvrIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSvrIP.Name = "txtSvrIP";
            this.txtSvrIP.Size = new System.Drawing.Size(152, 21);
            this.txtSvrIP.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "Server IP";
            // 
            // txtChatList
            // 
            this.txtChatList.BackColor = System.Drawing.SystemColors.Window;
            this.txtChatList.Location = new System.Drawing.Point(11, 40);
            this.txtChatList.Multiline = true;
            this.txtChatList.Name = "txtChatList";
            this.txtChatList.ReadOnly = true;
            this.txtChatList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatList.Size = new System.Drawing.Size(594, 424);
            this.txtChatList.TabIndex = 48;
            this.txtChatList.Text = "[Chat List]";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(11, 473);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(519, 64);
            this.txtMsg.TabIndex = 48;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(535, 472);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 64);
            this.btnSend.TabIndex = 39;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // ClientList
            // 
            this.ClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID});
            this.ClientList.HideSelection = false;
            this.ClientList.Location = new System.Drawing.Point(611, 64);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(174, 473);
            this.ClientList.TabIndex = 54;
            this.ClientList.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "[Client List]";
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 546);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtChatList);
            this.Controls.Add(this.txtCliID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSvrIP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "clientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.clientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtCliID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSvrIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtChatList;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView ClientList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Label label3;
    }
}

