using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class SPORT
    {
        public SPORT()
        {
            this.LIEUx = new List<LIEU>();
            this.UTILISATEURs = new List<UTILISATEUR>();
        }

        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }
        public virtual ICollection<LIEU> LIEUx { get; set; }
        public virtual ICollection<UTILISATEUR> UTILISATEURs { get; set; }
    }
}
