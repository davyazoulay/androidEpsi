using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class PUBLICATION
    {
        public PUBLICATION()
        {
            this.MESSAGE_PUBLICATION = new List<MESSAGE_PUBLICATION>();
        }

        public int id { get; set; }
        public Nullable<int> id_groupe { get; set; }
        public Nullable<int> id_emmeteur { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public virtual GROUPE GROUPE { get; set; }
        public virtual ICollection<MESSAGE_PUBLICATION> MESSAGE_PUBLICATION { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
    }
}
