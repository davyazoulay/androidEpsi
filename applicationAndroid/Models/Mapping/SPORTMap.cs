using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class SPORTMap : EntityTypeConfiguration<SPORT>
    {
        public SPORTMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nom)
                .HasMaxLength(50);

            this.Property(t => t.type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SPORT");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.type).HasColumnName("type");

            // Relationships
            this.HasMany(t => t.UTILISATEURs)
                .WithMany(t => t.SPORTs)
                .Map(m =>
                    {
                        m.ToTable("ASSO_UTILISATEUR_SPORT");
                        m.MapLeftKey("id_sport");
                        m.MapRightKey("id_utilisateur");
                    });


        }
    }
}
