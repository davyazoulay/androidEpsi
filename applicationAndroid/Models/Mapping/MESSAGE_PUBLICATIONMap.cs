using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class MESSAGE_PUBLICATIONMap : EntityTypeConfiguration<MESSAGE_PUBLICATION>
    {
        public MESSAGE_PUBLICATIONMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_publication, t.id_emetteur });

            // Properties
            this.Property(t => t.id_publication)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_emetteur)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.message)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("MESSAGE_PUBLICATION");
            this.Property(t => t.id_publication).HasColumnName("id_publication");
            this.Property(t => t.id_emetteur).HasColumnName("id_emetteur");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.date).HasColumnName("date");

            // Relationships
            this.HasRequired(t => t.UTILISATEUR)
                .WithMany(t => t.MESSAGE_PUBLICATION)
                .HasForeignKey(d => d.id_emetteur);
            this.HasRequired(t => t.PUBLICATION)
                .WithMany(t => t.MESSAGE_PUBLICATION)
                .HasForeignKey(d => d.id_publication);

        }
    }
}
