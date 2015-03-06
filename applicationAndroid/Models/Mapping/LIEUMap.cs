using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class LIEUMap : EntityTypeConfiguration<LIEU>
    {
        public LIEUMap()
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

            this.Property(t => t.code_postal)
                .HasMaxLength(5);

            this.Property(t => t.latitude)
                .HasMaxLength(50);

            this.Property(t => t.longitude)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LIEU");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.libelle).HasColumnName("libelle");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.code_postal).HasColumnName("code_postal");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longitude).HasColumnName("longitude");

            // Relationships
            this.HasMany(t => t.SPORTs)
                .WithMany(t => t.LIEUx)
                .Map(m =>
                    {
                        m.ToTable("ASSO_SPORT_LIEU");
                        m.MapLeftKey("id_lieu");
                        m.MapRightKey("id_sport");
                    });

            this.HasMany(t => t.VILLEs)
                .WithMany(t => t.LIEUx)
                .Map(m =>
                    {
                        m.ToTable("ASSO_VILLE_LIEU");
                        m.MapLeftKey("id_lieu");
                        m.MapRightKey("id_ville");
                    });


        }
    }
}
