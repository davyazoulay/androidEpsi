using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class VILLE
    {
        public VILLE()
        {
            this.LIEUx = new List<LIEU>();
        }

        public int id { get; set; }
        public string nom { get; set; }
        public virtual ICollection<LIEU> LIEUx { get; set; }
    }
}
