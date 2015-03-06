using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class ASSO_NOTE_LIEUMap : EntityTypeConfiguration<ASSO_NOTE_LIEU>
    {
        public ASSO_NOTE_LIEUMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_utilisateur, t.id_lieu });

            // Properties
            this.Property(t => t.id_utilisateur)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_lieu)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.message)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ASSO_NOTE_LIEU");
            this.Property(t => t.id_utilisateur).HasColumnName("id_utilisateur");
            this.Property(t => t.id_lieu).HasColumnName("id_lieu");
            this.Property(t => t.note).HasColumnName("note");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.date).HasColumnName("date");

            // Relationships
            this.HasRequired(t => t.LIEU)
                .WithMany(t => t.ASSO_NOTE_LIEU)
                .HasForeignKey(d => d.id_lieu);
            this.HasRequired(t => t.UTILISATEUR)
                .WithMany(t => t.ASSO_NOTE_LIEU)
                .HasForeignKey(d => d.id_utilisateur);

        }
    }
}
