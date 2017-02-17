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

        public enum ActionResult { SUCCESS = 0, NOT_ENOUGH_PERMISSIONS = 1, PRIVATE_CHAT = 2, USER_EXISTS = 3, GENERAL_FAIL = 100 }
        private IHubProxy LoginHub { get; set; }
        public IHubProxy UserHub { get; set; }
        private IHubProxy MessageHub { get; set; }
        private IHubProxy ChatRoomHub { get; set; }

        public List<User> contactList = new List<User>();

        public List<User> addcontactList = new List<User>();

        public List<int> open = new List<int>();

        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 20;

        public List<Message> messageList = new List<Message>();

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
        public async void ConnectAsync()
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
            await UserHub.Invoke<List<User>>("GetContacts").ContinueWith(task =>
            {
                if(task.IsFaulted)
                {
                    MessageBox.Show("Hovno");
                }
                else
                {
                    contactList = task.Result;

                    //this.Invoke((Action)(() =>
                    //UserList.Items.Clear()));


                    /*for (int i = 0; i < contactList.LongCount(); i++)
                     {
                         this.Invoke((Action)(() =>
                     UserList.Items.Add(String.Format(contactList[i].Name))));

                     }*/
                    this.Invoke((Action)(() =>
                   ContactsBtn.PerformClick()));
                   
                }
            });
            await ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    MessageBox.Show("Hovno");
                }
                else
                {
                    roomList = task.Result;
                }
            });
            await UserHub.Invoke<List<User>>("FindContact", u).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    MessageBox.Show("Hovno");
                }
                else
                {
                    //addcontactList = task.Result;

                    addcontactList = task.Result;

                }
            });
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
            this.addcontactList = addcontactList;
        }


        private void AddContactBtn_Click(object sender, EventArgs e)
        {
            AddContactForm form2 = new AddContactForm(UserHub);
            form2.passList(this.addcontactList);
            form2.Show();
            form2.parent = this;
        }

        public void ContactsBtn_Click(object sender, EventArgs e)
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
            UserList.DisplayMember = "Name";
            for (int i = 0; i < roomList.LongCount(); i++)
            {
                UserList.Items.Add(roomList[i]);
            }
        }
       /* public async void Messages()
        {
            int sel = UserList.SelectedIndex;
            messageList = await MessageHub.Invoke<List<Message>>("GetRoomMessages", roomList[sel].Id).ConfigureAwait(false);
        }*/
        private async void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inContacts)
            {
                int sel;
                lock (UserList)
                {
                    sel = UserList.SelectedIndex;
                }
                //ChatRoom kok = await ChatRoomHub.Invoke<ChatRoom>("CreateRoom", contactList[sel].Id).ConfigureAwait(false);
                //switchRooms();
                Task<ChatRoom> tasker = ChatRoomHub.Invoke<ChatRoom>("CreateRoom", contactList[sel].Id);
                tasker.Wait();
                await ChatRoomHub.Invoke<List<ChatRoom>>("GetUserRooms").ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        MessageBox.Show("Failed to load rooms");
                    }
                    else
                    {
                        roomList = task.Result;
                    }
                });
                RoomsBtn.PerformClick();


                //Task<List<User>> tasker = ChatRoomHub.Invoke<List<User>>("CreateRoom", contactList[sel].Id);
            }

            else
            {
                string title = ((ChatRoom)UserList.SelectedItem).Name;
                int id = roomList[UserList.SelectedIndex].Id;


                bool found = false;

                for (int i = 0; i < open.Count; i++)
                {
                    if (open[i] == id)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    int sel = ((ChatRoom)UserList.SelectedItem).Id;
                    /* int sel = 0;
                     if (UserList.InvokeRequired)
                     UserList.Invoke((MethodInvoker)
                         delegate
                         {
                             sel = ((ChatRoom)UserList.SelectedItem).Id;
                         });
                     else
                         sel = ((ChatRoom)UserList.SelectedItem).Id;
                         */
                    open.Add(id);
                    
                    TabPage page = new TabPage();
                    RichTextBox rtb = new RichTextBox();
                    page.Text = title;
                    page.Controls.Add(rtb);
                    ChatTabControl.TabPages.Add(page);
                    rtb.Dock = DockStyle.Fill;
                    rtb.ReadOnly = true;
                    ChatTabControl.SizeMode = TabSizeMode.Fixed;
                    Tabdraw();
                    //currentRoom.Text = id.ToString();
                    
                    MessageHub.On<Message, ChatRoom>("OnNewMessage", (Message message, ChatRoom room) => {
                        if(room.Id == id)
                        {
                            this.Invoke((Action)(() =>
                            rtb.AppendText(message.Sender.Name + ": " + message.Text + "\n")));
                        }
                        
                    });

                    await MessageHub.Invoke<List<Message>>("GetRoomMessages", sel).ContinueWith(task =>
                        {
                            if (task.IsFaulted)
                            {
                                MessageBox.Show("Failed to load messages");
                            }
                            else
                            {
                                messageList = task.Result;
                            }
                        });


                    foreach (Message m in messageList) {

                        //rtb.Text += m.Text + "\n";
                        rtb.AppendText(m.Sender.Name + ": " + m.Text + "\n");

                    }
                }
            }
        }

        public void Tabdraw()
        {
            int tabLength = ChatTabControl.ItemSize.Width;

            for (int i = 0; i < this.ChatTabControl.TabPages.Count; i++)
            {
                TabPage currentPage = ChatTabControl.TabPages[i];

                int currentTabLength = TextRenderer.MeasureText(currentPage.Text, ChatTabControl.Font).Width;
                // adjust the length for what text is written
                currentTabLength += LEADING_SPACE + CLOSE_SPACE + CLOSE_AREA;

                if (currentTabLength > tabLength)
                {
                    tabLength = currentTabLength;
                }
            }
            Size newTabSize = new Size(tabLength, ChatTabControl.ItemSize.Height);
            ChatTabControl.ItemSize = newTabSize;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChatTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("X", e.Font, Brushes.Black, e.Bounds.Right - CLOSE_AREA, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.ChatTabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + LEADING_SPACE, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void ChatTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.ChatTabControl.TabPages.Count; i++)
            {
                Rectangle r = ChatTabControl.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - CLOSE_AREA, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.ChatTabControl.TabPages.RemoveAt(i);
                        open.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private async void SendBtn_Click(object sender, EventArgs e)
        {
            ActionResult res = await MessageHub.Invoke<ActionResult>("NewMessage", MessageField.Text, open[ChatTabControl.SelectedIndex]).ConfigureAwait(false);
            this.Invoke((Action)(() =>
                    MessageField.Text = string.Empty));



        }

        private void MessageField_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private async void MessageField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActionResult res = await MessageHub.Invoke<ActionResult>("NewMessage", MessageField.Text, open[ChatTabControl.SelectedIndex]).ConfigureAwait(false);
                this.Invoke((Action)(() =>
                        MessageField.Text = string.Empty));
            }
        }

        private void CloseRegBtn_Click(object sender, EventArgs e)
        {
            RegPanel.Hide();
        }

        private void RegPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    }

