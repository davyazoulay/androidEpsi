using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class MessageChat
    {
        public int IdEmmeteur { get; set; }
        public int IdDestinataire { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public MessageChat() { }

        public MessageChat(int idEmmet, int idDest, string msg, DateTime date)
        {
            IdEmmeteur = idEmmet;
            IdDestinataire = idDest;
            Message = msg;
            Date = date;
        }
    }
}
