using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class PUBLICATIONMap : EntityTypeConfiguration<PUBLICATION>
    {
        public PUBLICATIONMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.message)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("PUBLICATION");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_groupe).HasColumnName("id_groupe");
            this.Property(t => t.id_emmeteur).HasColumnName("id_emmeteur");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.date).HasColumnName("date");

            // Relationships
            this.HasOptional(t => t.GROUPE)
                .WithMany(t => t.PUBLICATIONs)
                .HasForeignKey(d => d.id_groupe);
            this.HasOptional(t => t.UTILISATEUR)
                .WithMany(t => t.PUBLICATIONs)
                .HasForeignKey(d => d.id_emmeteur);

        }
    }
}
