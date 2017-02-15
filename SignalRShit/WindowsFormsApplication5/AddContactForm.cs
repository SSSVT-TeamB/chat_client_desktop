using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class AddContactForm : Form
    {
        List<User> addcontactList = new List<User>();
        public enum ActionResult { SUCCESS = 0, NOT_ENOUGH_PERMISSIONS = 1, PRIVATE_CHAT = 2, USER_EXISTS = 3, GENERAL_FAIL = 100 }
        public void passList(List<User> addcontactList)
        {
            this.addcontactList = addcontactList;
        }
        public AddContactForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MainForm form2 = new MainForm();

            int sel = AddContactL.SelectedIndex;
            MessageBox.Show(addcontactList.Count.ToString());
            ActionResult result = await form2.UserHub.Invoke<ActionResult>("AddContact", addcontactList[sel].Id).ConfigureAwait(false);
           
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
                for (int i = 0; i < addcontactList.Count; i++)
                {
                    AddContactL.Items.Add(String.Format(addcontactList[i].Name));
                }
            
        }

        private void AddContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
