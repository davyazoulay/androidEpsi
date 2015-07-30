using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class MessageIntitule
    {
        public int IdAmi { get; set; }
        public string NomAmi { get; set; }
        public bool CestMoi { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public MessageIntitule() { }

        public MessageIntitule(int idAmi, string nomAmi, bool cestmoi, string message, DateTime date)
        {
            IdAmi = idAmi;
            NomAmi = nomAmi;
            CestMoi = cestmoi;
            Message = message;
            Date = date;
        }
    }
}
