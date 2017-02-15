namespace WindowsFormsApplication5
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SignInPanel = new System.Windows.Forms.Panel();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.RegPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.PasswordReg = new System.Windows.Forms.TextBox();
            this.LoginReg = new System.Windows.Forms.TextBox();
            this.UsernameReg = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SignInButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ChatPanel2 = new System.Windows.Forms.Panel();
            this.AddContactBtn = new System.Windows.Forms.Button();
            this.ContactsBtn = new System.Windows.Forms.Button();
            this.RoomsBtn = new System.Windows.Forms.Button();
            this.UserList = new System.Windows.Forms.ListBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.MessageField = new System.Windows.Forms.TextBox();
            this.ChatTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SignInPanel.SuspendLayout();
            this.RegPanel.SuspendLayout();
            this.ChatPanel2.SuspendLayout();
            this.ChatTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // SignInPanel
            // 
            this.SignInPanel.Controls.Add(this.StatusTxt);
            this.SignInPanel.Controls.Add(this.RegPanel);
            this.SignInPanel.Controls.Add(this.linkLabel1);
            this.SignInPanel.Controls.Add(this.PasswordTextBox);
            this.SignInPanel.Controls.Add(this.SignInButton);
            this.SignInPanel.Controls.Add(this.UserNameTextBox);
            this.SignInPanel.Controls.Add(this.label4);
            this.SignInPanel.Controls.Add(this.label5);
            this.SignInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignInPanel.Location = new System.Drawing.Point(0, 0);
            this.SignInPanel.Name = "SignInPanel";
            this.SignInPanel.Size = new System.Drawing.Size(880, 596);
            this.SignInPanel.TabIndex = 0;
            // 
            // StatusTxt
            // 
            this.StatusTxt.Location = new System.Drawing.Point(285, 32);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(332, 20);
            this.StatusTxt.TabIndex = 7;
            // 
            // RegPanel
            // 
            this.RegPanel.Controls.Add(this.label3);
            this.RegPanel.Controls.Add(this.label2);
            this.RegPanel.Controls.Add(this.label1);
            this.RegPanel.Controls.Add(this.button2);
            this.RegPanel.Controls.Add(this.PasswordReg);
            this.RegPanel.Controls.Add(this.LoginReg);
            this.RegPanel.Controls.Add(this.UsernameReg);
            this.RegPanel.Location = new System.Drawing.Point(197, 151);
            this.RegPanel.Name = "RegPanel";
            this.RegPanel.Size = new System.Drawing.Size(482, 267);
            this.RegPanel.TabIndex = 5;
            this.RegPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passwort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reg";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PasswordReg
            // 
            this.PasswordReg.Location = new System.Drawing.Point(161, 132);
            this.PasswordReg.Name = "PasswordReg";
            this.PasswordReg.PasswordChar = '♥';
            this.PasswordReg.Size = new System.Drawing.Size(176, 20);
            this.PasswordReg.TabIndex = 2;
            // 
            // LoginReg
            // 
            this.LoginReg.Location = new System.Drawing.Point(161, 80);
            this.LoginReg.Name = "LoginReg";
            this.LoginReg.Size = new System.Drawing.Size(176, 20);
            this.LoginReg.TabIndex = 0;
            // 
            // UsernameReg
            // 
            this.UsernameReg.Location = new System.Drawing.Point(161, 106);
            this.UsernameReg.Name = "UsernameReg";
            this.UsernameReg.Size = new System.Drawing.Size(176, 20);
            this.UsernameReg.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(412, 320);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(96, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Not registered yet?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(347, 262);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '♥';
            this.PasswordTextBox.Size = new System.Drawing.Size(226, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "blyat";
            // 
            // SignInButton
            // 
            this.SignInButton.Location = new System.Drawing.Point(420, 288);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(75, 23);
            this.SignInButton.TabIndex = 3;
            this.SignInButton.Text = "Sign in";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(347, 236);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(226, 20);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.Text = "Marek";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // ChatPanel2
            // 
            this.ChatPanel2.Controls.Add(this.AddContactBtn);
            this.ChatPanel2.Controls.Add(this.ContactsBtn);
            this.ChatPanel2.Controls.Add(this.RoomsBtn);
            this.ChatPanel2.Controls.Add(this.UserList);
            this.ChatPanel2.Controls.Add(this.SendBtn);
            this.ChatPanel2.Controls.Add(this.MessageField);
            this.ChatPanel2.Controls.Add(this.ChatTabControl);
            this.ChatPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel2.Location = new System.Drawing.Point(0, 0);
            this.ChatPanel2.Name = "ChatPanel2";
            this.ChatPanel2.Size = new System.Drawing.Size(880, 596);
            this.ChatPanel2.TabIndex = 3;
            this.ChatPanel2.Visible = false;
            // 
            // AddContactBtn
            // 
            this.AddContactBtn.Location = new System.Drawing.Point(720, 16);
            this.AddContactBtn.Name = "AddContactBtn";
            this.AddContactBtn.Size = new System.Drawing.Size(94, 23);
            this.AddContactBtn.TabIndex = 5;
            this.AddContactBtn.Text = "Add contact";
            this.AddContactBtn.UseVisualStyleBackColor = true;
            this.AddContactBtn.Click += new System.EventHandler(this.AddContactBtn_Click);
            // 
            // ContactsBtn
            // 
            this.ContactsBtn.Location = new System.Drawing.Point(665, 45);
            this.ContactsBtn.Name = "ContactsBtn";
            this.ContactsBtn.Size = new System.Drawing.Size(91, 23);
            this.ContactsBtn.TabIndex = 3;
            this.ContactsBtn.Text = "Contacts";
            this.ContactsBtn.UseVisualStyleBackColor = true;
            this.ContactsBtn.Click += new System.EventHandler(this.ContactsBtn_Click);
            // 
            // RoomsBtn
            // 
            this.RoomsBtn.Location = new System.Drawing.Point(777, 45);
            this.RoomsBtn.Name = "RoomsBtn";
            this.RoomsBtn.Size = new System.Drawing.Size(91, 23);
            this.RoomsBtn.TabIndex = 3;
            this.RoomsBtn.Text = "Rooms";
            this.RoomsBtn.UseVisualStyleBackColor = true;
            this.RoomsBtn.Click += new System.EventHandler(this.RoomsBtn_Click);
            // 
            // UserList
            // 
            this.UserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 16;
            this.UserList.Location = new System.Drawing.Point(665, 74);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(203, 500);
            this.UserList.TabIndex = 2;
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(560, 562);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(99, 23);
            this.SendBtn.TabIndex = 1;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            // 
            // MessageField
            // 
            this.MessageField.Location = new System.Drawing.Point(10, 564);
            this.MessageField.Name = "MessageField";
            this.MessageField.Size = new System.Drawing.Size(544, 20);
            this.MessageField.TabIndex = 0;
            // 
            // ChatTabControl
            // 
            this.ChatTabControl.Controls.Add(this.tabPage1);
            this.ChatTabControl.Location = new System.Drawing.Point(10, 31);
            this.ChatTabControl.Name = "ChatTabControl";
            this.ChatTabControl.SelectedIndex = 0;
            this.ChatTabControl.Size = new System.Drawing.Size(649, 531);
            this.ChatTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 596);
            this.Controls.Add(this.ChatPanel2);
            this.Controls.Add(this.SignInPanel);
            this.Name = "MainForm";
            this.Text = "1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SignInPanel.ResumeLayout(false);
            this.SignInPanel.PerformLayout();
            this.RegPanel.ResumeLayout(false);
            this.RegPanel.PerformLayout();
            this.ChatPanel2.ResumeLayout(false);
            this.ChatPanel2.PerformLayout();
            this.ChatTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Panel SignInPanel;
        private System.Windows.Forms.Panel RegPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox PasswordReg;
        private System.Windows.Forms.TextBox UsernameReg;
        private System.Windows.Forms.TextBox LoginReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox MessageField;
        private System.Windows.Forms.TabControl ChatTabControl;
        private System.Windows.Forms.Button ContactsBtn;
        private System.Windows.Forms.Button RoomsBtn;
        private System.Windows.Forms.Button AddContactBtn;
        private System.Windows.Forms.TextBox StatusTxt;
        public System.Windows.Forms.Panel ChatPanel2;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

