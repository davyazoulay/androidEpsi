using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class GROUPEMap : EntityTypeConfiguration<GROUPE>
    {
        public GROUPEMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nom)
                .HasMaxLength(50);

            this.Property(t => t.libelle)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("GROUPE");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.libelle).HasColumnName("libelle");
            this.Property(t => t.description).HasColumnName("description");

            // Relationships
            this.HasMany(t => t.UTILISATEURs)
                .WithMany(t => t.GROUPEs)
                .Map(m =>
                    {
                        m.ToTable("ASSO_UTILISATEUR_GROUPE");
                        m.MapLeftKey("id_groupe");
                        m.MapRightKey("id_utilisateur");
                    });


        }
    }
}
