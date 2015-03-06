using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class CHAT_ENTRE_UTILISATEURS
    {
        public int id_utilisateur1 { get; set; }
        public int id_utilisateur2 { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
        public virtual UTILISATEUR UTILISATEUR1 { get; set; }
    }
}
