using System;
using System.Collections.Generic;

namespace applicationAndroid.Models
{
    public partial class UTILISATEUR
    {
        public UTILISATEUR()
        {
            this.ASSO_NOTE_LIEU = new List<ASSO_NOTE_LIEU>();
            this.CHAT_ENTRE_UTILISATEURS = new List<CHAT_ENTRE_UTILISATEURS>();
            this.CHAT_ENTRE_UTILISATEURS1 = new List<CHAT_ENTRE_UTILISATEURS>();
            this.MESSAGE_PUBLICATION = new List<MESSAGE_PUBLICATION>();
            this.PUBLICATIONs = new List<PUBLICATION>();
            this.UTILISATEUR1 = new List<UTILISATEUR>();
            this.UTILISATEURs = new List<UTILISATEUR>();
            this.GROUPEs = new List<GROUPE>();
            this.SPORTs = new List<SPORT>();
        }

        public int id { get; set; }
        public string login { get; set; }
        public string mdp { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> date_naissance { get; set; }
        public string pays { get; set; }
        public string ville { get; set; }
        public string code_postal { get; set; }
        public virtual ICollection<ASSO_NOTE_LIEU> ASSO_NOTE_LIEU { get; set; }
        public virtual ICollection<CHAT_ENTRE_UTILISATEURS> CHAT_ENTRE_UTILISATEURS { get; set; }
        public virtual ICollection<CHAT_ENTRE_UTILISATEURS> CHAT_ENTRE_UTILISATEURS1 { get; set; }
        public virtual ICollection<MESSAGE_PUBLICATION> MESSAGE_PUBLICATION { get; set; }
        public virtual ICollection<PUBLICATION> PUBLICATIONs { get; set; }
        public virtual ICollection<UTILISATEUR> UTILISATEUR1 { get; set; }
        public virtual ICollection<UTILISATEUR> UTILISATEURs { get; set; }
        public virtual ICollection<GROUPE> GROUPEs { get; set; }
        public virtual ICollection<SPORT> SPORTs { get; set; }
    }
}
