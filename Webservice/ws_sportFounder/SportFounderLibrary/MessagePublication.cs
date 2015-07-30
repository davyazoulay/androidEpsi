using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class MessagePublication
    {
        public int IdPublication { get; set; }
        public int IdEmmeteur { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public MessagePublication(){}

    }
}
