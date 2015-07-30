using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Conversation
    {
        public int UserId { get; set; }
        public string UserNom { get; set; }
        public List<MessageSimple> Messages { get; set; }

        public Conversation() { }

        public Conversation(int userId)
        {
            UserId = userId;
            Messages = new List<MessageSimple>();
        }
    }
}
