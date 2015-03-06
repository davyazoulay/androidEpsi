using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using applicationAndroid.Models.Mapping;

namespace applicationAndroid.Models
{
    public partial class appli_androidContext : DbContext
    {
        static appli_androidContext()
        {
            Database.SetInitializer<appli_androidContext>(null);
        }

        public appli_androidContext()
            : base("Name=appli_androidContext")
        {
        }

        public DbSet<ASSO_NOTE_LIEU> ASSO_NOTE_LIEU { get; set; }
        public DbSet<CHAT_ENTRE_UTILISATEURS> CHAT_ENTRE_UTILISATEURS { get; set; }
        public DbSet<GROUPE> GROUPEs { get; set; }
        public DbSet<LIEU> LIEUx { get; set; }
        public DbSet<MESSAGE_PUBLICATION> MESSAGE_PUBLICATION { get; set; }
        public DbSet<PUBLICATION> PUBLICATIONs { get; set; }
        public DbSet<SPORT> SPORTs { get; set; }
        public DbSet<UTILISATEUR> UTILISATEURs { get; set; }
        public DbSet<VILLE> VILLEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ASSO_NOTE_LIEUMap());
            modelBuilder.Configurations.Add(new CHAT_ENTRE_UTILISATEURSMap());
            modelBuilder.Configurations.Add(new GROUPEMap());
            modelBuilder.Configurations.Add(new LIEUMap());
            modelBuilder.Configurations.Add(new MESSAGE_PUBLICATIONMap());
            modelBuilder.Configurations.Add(new PUBLICATIONMap());
            modelBuilder.Configurations.Add(new SPORTMap());
            modelBuilder.Configurations.Add(new UTILISATEURMap());
            modelBuilder.Configurations.Add(new VILLEMap());
        }
    }
}
