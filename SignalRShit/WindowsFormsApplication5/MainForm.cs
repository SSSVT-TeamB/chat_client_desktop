using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.AspNet.SignalR.Client;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Contexts;
using System.Net;

namespace WindowsFormsApplication5
{
    public partial class MainForm : Form
    {
        public User user = null;
        public string u = string.Empty;
        private IHubProxy LoginHub { get; set; }
        public IHubProxy UserHub { get; set; }
        private IHubProxy MessageHub { get; set; }
        private IHubProxy ChatRoomHub { get; set; }

        public List<User> contactList = new List<User>();

        public List<User> addcontactList = new List<User>();

        public List<string> open = new List<string>();

        public List<Message> messageList = new List<Message>();
        public enum ActionResult { SUCCESS = 0, NOT_ENOUGH_PERMISSIONS = 1, PRIVATE_CHAT = 2, USER_EXISTS = 3, GENERAL_FAIL = 100 }

        public List<ChatRoom> roomList = new List<ChatRoom>();
        public bool inContacts = false;
        const string ServerURI = "http://82.202.68.136:8080";

        private HubConnection Connection { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectAsync();

        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            LoginHub = Connection.CreateHubProxy("loginHub");
            UserHub = Connection.CreateHubProxy("UserHub");
            MessageHub = Connection.CreateHubProxy("MessageHub");
            ChatRoomHub = Connection.CreateHubProxy("ChatRoomHub");
            /*HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Invoke((Action)(() =>
                    RichTextBoxConsole.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                ))
            );*/
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                //StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
                return;
            }

            //SignInPanel.Visible = false;
            //ChatPanel.Visible = true;
            //ButtonSend.Enabled = true;
            //TextBoxMessage.Focus();
            StatusTxt.AppendText("Connected to server at " + ServerURI + Environment.NewLine);
        }
        public async void Initialise()
        {
            contactList = await UserHub.Invoke<List<User>>("GetContacts").ConfigureAwait(false);
            roomList = await ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms").ConfigureAwait(false);
            addcontactList = await UserHub.Invoke<List<User>>("FindContact", u).ConfigureAwait(false);
            MessageBox.Show(addcontactList.Count.ToString());
        }
        private void Connection_Closed()
        {
            /*this.Invoke((Action)(() => ChatPanel.Visible = false));
            this.Invoke((Action)(() => ButtonSend.Enabled = false));
            this.Invoke((Action)(() => StatusText.Text = "You have been disconnected."));*/
            this.Invoke((Action)(() => SignInPanel.Visible = true));
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserNameTextBox.Text))
            {
                Login l = new Login();
                l.Username = UserNameTextBox.Text;
                l.Password = PasswordTextBox.Text;

                Task<User> tasker = LoginHub.Invoke<User>("Authentificate", l);
                tasker.Wait();

                if (tasker.Result == null)
                {
                    MessageBox.Show("Incorrect password");

                }

                else
                {
                    Initialise();
                    SignInPanel.Visible = false;
                    ChatPanel2.Visible = true;

                    /*contactList = UserHub.Invoke<List<User>>("GetContacts").Result;
                    roomList = ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms").Result;
                    addcontactList = UserHub.Invoke<List<User>>("FindContact", "").Result;*/

                    /*Task<List<User>> tasker2 = UserHub.Invoke<List<User>>("GetContacts");
                    tasker2.Wait();
                    MessageBox.Show(tasker2.IsFaulted.ToString());
                    contactList = tasker2.Result;

                    Task<List<ChatRoom>> tasker3 = ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms");
                    tasker3.Wait();
                    roomList = tasker3.Result;

                    /*Task<List<User>> tasker4 = UserHub.Invoke<List<User>>("FindContact", "");
                    tasker4.Wait();
                    addcontactList = tasker4.Result;*/

                }
            }
        }

        public void connected()
        {
            SignInPanel.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SignInPanel.Visible = false;
            RegPanel.Visible = true;
        }

        public bool register(string login, string password, string name)
        {
            Login tmp = new Login();
            tmp.Username = login;
            tmp.Password = password;

            Task<int> tasker = LoginHub.Invoke<int>("Register", tmp, name);
            tasker.Wait();

            if (tasker.Result == 3)
            {
                MessageBox.Show("Username exists");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (register(LoginReg.Text, PasswordReg.Text, UsernameReg.Text) == true)
            {
                MessageBox.Show("OK");
                RegPanel.Visible = false;
            };
        }
        public void passList(List<User> addcontactList)
        {
            this.contactList = contactList;
        }

        private void AddContactBtn_Click(object sender, EventArgs e)
        {
            AddContactForm form2 = new AddContactForm();
            form2.passList(this.addcontactList);
            form2.Show();
        }

        private void ContactsBtn_Click(object sender, EventArgs e)
        {
            inContacts = true;
            UserList.Items.Clear();
            for (int i = 0; i < contactList.LongCount(); i++)
            {
                UserList.Items.Add(String.Format(contactList[i].Name));
            }

        }

        private void RoomsBtn_Click(object sender, EventArgs e)
        {
            switchRooms();
        }

        private void switchRooms() {
            inContacts = false;
            UserList.Items.Clear();
            for (int i = 0; i < roomList.LongCount(); i++)
            {
                UserList.Items.Add(String.Format(roomList[i].Name));
            }
        }
        private async void kopec()
        {
            
            roomList = await ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms").ConfigureAwait(false);

        }
        public async void Messages()
        {
            int sel = UserList.SelectedIndex;
            messageList = await MessageHub.Invoke<List<Message>>("GetRoomMessages", roomList[sel].Id).ConfigureAwait(false);
        }

        private async void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inContacts)
            {
                int sel = UserList.SelectedIndex;
                //ChatRoom kok = await ChatRoomHub.Invoke<ChatRoom>("CreateRoom", contactList[sel].Id).ConfigureAwait(false);
                //switchRooms();
                Task<ChatRoom> tasker = ChatRoomHub.Invoke<ChatRoom>("CreateRoom", contactList[sel].Id);
                tasker.Wait();
                kopec();
                RoomsBtn.PerformClick();
                
                
                //Task<List<User>> tasker = ChatRoomHub.Invoke<List<User>>("CreateRoom", contactList[sel].Id);
            }

            else
            {
                string title = UserList.SelectedItem.ToString();

                bool found = false;
                for (int i = 0; i < open.Count; i++)
                {
                    if (open[i] == title)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    int sel = UserList.SelectedIndex;
                    messageList = await MessageHub.Invoke<List<Message>>("GetRoomMessages", roomList[sel].Id).ConfigureAwait(false);

                    open.Add(UserList.SelectedItem.ToString());
                    TabPage myTabPage = new TabPage(title);
                    ChatTabControl.TabPages.Add(myTabPage);
                    var newRichTextBox = new RichTextBox()
                    {
                        Dock = 
                        };

                }


            }

            }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

