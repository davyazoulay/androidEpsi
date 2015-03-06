using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class CHAT_ENTRE_UTILISATEURSMap : EntityTypeConfiguration<CHAT_ENTRE_UTILISATEURS>
    {
        public CHAT_ENTRE_UTILISATEURSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_utilisateur1, t.id_utilisateur2 });

            // Properties
            this.Property(t => t.id_utilisateur1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_utilisateur2)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.message)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("CHAT_ENTRE_UTILISATEURS");
            this.Property(t => t.id_utilisateur1).HasColumnName("id_utilisateur1");
            this.Property(t => t.id_utilisateur2).HasColumnName("id_utilisateur2");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.date).HasColumnName("date");

            // Relationships
            this.HasRequired(t => t.UTILISATEUR)
                .WithMany(t => t.CHAT_ENTRE_UTILISATEURS)
                .HasForeignKey(d => d.id_utilisateur1);
            this.HasRequired(t => t.UTILISATEUR1)
                .WithMany(t => t.CHAT_ENTRE_UTILISATEURS1)
                .HasForeignKey(d => d.id_utilisateur2);

        }
    }
}
