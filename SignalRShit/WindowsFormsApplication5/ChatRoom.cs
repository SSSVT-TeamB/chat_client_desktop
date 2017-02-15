using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public class ChatRoom
    {
        public List<ChatRoomMember> Clients = new List<ChatRoomMember>();
        public String Name { get; set; }

        public User Owner { get; set; }
        public int Id { get; set; }


    }
}
