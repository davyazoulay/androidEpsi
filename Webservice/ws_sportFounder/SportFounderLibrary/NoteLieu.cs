using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class NoteLieu
    {
        public int IdUtilisateur { get; set; }
        public int IdLieu { get; set; }
        public int Note { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
