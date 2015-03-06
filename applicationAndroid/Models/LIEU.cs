using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class LIEU
    {
        public LIEU()
        {
            this.ASSO_NOTE_LIEU = new List<ASSO_NOTE_LIEU>();
            this.SPORTs = new List<SPORT>();
            this.VILLEs = new List<VILLE>();
        }

        public int id { get; set; }
        public string nom { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public string code_postal { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public virtual ICollection<ASSO_NOTE_LIEU> ASSO_NOTE_LIEU { get; set; }
        public virtual ICollection<SPORT> SPORTs { get; set; }
        public virtual ICollection<VILLE> VILLEs { get; set; }
    }
}
