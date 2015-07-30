using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class ChatEntreUtilisateurs
    {
        public int IdExpediteur { get; set; }
        public int IdDestinataire { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
