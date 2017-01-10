﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                PasswordTxt.Focus();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(UsernameTxt.Text))
            {
                MessageBox.Show("Pls enter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsernameTxt.Focus();
                return;
            }
            try
            {
                dbchatDataSetTableAdapters.usersTableAdapter user = new dbchatDataSetTableAdapters.usersTableAdapter();
                dbchatDataSet.usersDataTable dt = user.Login(UsernameTxt.Text, PasswordTxt.Text);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Welcome", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Not today", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin.PerformClick();
        }

        private void š(object sender, EventArgs e)
        {

        }
    }
}
