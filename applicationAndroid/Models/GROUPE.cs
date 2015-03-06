using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class GROUPE
    {
        public GROUPE()
        {
            this.PUBLICATIONs = new List<PUBLICATION>();
            this.UTILISATEURs = new List<UTILISATEUR>();
        }

        public int id { get; set; }
        public string nom { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public virtual ICollection<PUBLICATION> PUBLICATIONs { get; set; }
        public virtual ICollection<UTILISATEUR> UTILISATEURs { get; set; }
    }
}
