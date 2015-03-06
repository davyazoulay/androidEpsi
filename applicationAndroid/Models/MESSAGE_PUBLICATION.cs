using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class MESSAGE_PUBLICATION
    {
        public int id_publication { get; set; }
        public int id_emetteur { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
        public virtual PUBLICATION PUBLICATION { get; set; }
    }
}
