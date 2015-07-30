using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class MessageSimple
    {
        public bool CestMoi { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public MessageSimple() { }

        public MessageSimple(bool cestMoi, string message, DateTime date)
        {
            CestMoi = cestMoi;
            Message = message;
            Date = date;
        }

        public MessageSimple(MessageChat msg_input, int myId)
        {
            if (msg_input.IdEmmeteur == myId)
                CestMoi = true;
            else
                CestMoi = false;
            Message = msg_input.Message;
            Date = msg_input.Date;
        }
    }
}
