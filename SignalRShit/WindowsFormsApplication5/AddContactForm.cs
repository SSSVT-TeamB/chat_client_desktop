using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class AddContactForm : Form
    {
       public IHubProxy UserHub { get; set; }
        private HubConnection Connection { get; set; }
        //const string ServerURI = "http://82.202.68.136:8080";

        public MainForm parent { get; set; }

        List<User> addcontactList = new List<User>();
        public enum ActionResult { SUCCESS = 0, NOT_ENOUGH_PERMISSIONS = 1, PRIVATE_CHAT = 2, USER_EXISTS = 3, GENERAL_FAIL = 100 }
        public void passList(List<User> addcontactList)
        {
            this.addcontactList = addcontactList;
        }
        public AddContactForm(IHubProxy UserHub)
        {
            InitializeComponent();
            this.UserHub = UserHub;
        }
        private void AddContactForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < addcontactList.Count; i++)
            {
                AddContactL.Items.Add(String.Format(addcontactList[i].Name));
            }
            //ConnectAsync();

        }
        public void LoadDt()
        {
            /*  this.Invoke((Action)(() =>
              AddContactL.Items.Clear()));
              for (int i = 0; i < addcontactList.Count; i++)
              {
                  this.Invoke((Action)(() =>
              AddContactL.Items.Add(String.Format(addcontactList[i].Name))));

              }*/

         /*   this.Invoke((Action)(() =>
            parent.inContacts = true));

            this.Invoke((Action)(() =>
            parent.UserList.Items.Clear()));
            
            for (int i = 0; i < parent.contactList.LongCount(); i++)
            {
                this.Invoke((Action)(() =>
            parent.UserList.Items.Add(String.Format(parent.contactList[i].Name))));
                
            }*/

        }


        /*    public async void ConnectAsync()
            {
                //Connection = new HubConnection(ServerURI);
                //UserHub = Connection.CreateHubProxy("UserHub");

                try
                {
                    await Connection.Start();
                }
                catch (HttpRequestException)
                {
                    //StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
                    return;
                }

            }*/

        private async void button1_Click(object sender, EventArgs e)
        {
            int sel = AddContactL.SelectedIndex;

            await UserHub.Invoke<ActionResult>("AddContact", addcontactList[sel].Id).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    MessageBox.Show("Blby no");

                }
                else
                {
                
                    parent.Initialise();

                    Thread.Sleep(500);
                    this.Invoke((Action)(() =>
                    AddContactL.Items.Clear()));


                    for (int i = 0; i < parent.addcontactList.LongCount(); i++)
                    {
                        this.Invoke((Action)(() =>
                    AddContactL.Items.Add(String.Format(parent.addcontactList[i].Name))));

                    }

                }
        });

        }

                
   

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void AddContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
