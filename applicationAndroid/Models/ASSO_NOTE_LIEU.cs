using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class ASSO_NOTE_LIEU
    {
        public int id_utilisateur { get; set; }
        public int id_lieu { get; set; }
        public int note { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public virtual LIEU LIEU { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
    }
}
