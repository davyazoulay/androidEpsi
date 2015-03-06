using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class VILLEMap : EntityTypeConfiguration<VILLE>
    {
        public VILLEMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nom)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VILLE");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nom).HasColumnName("nom");
        }
    }
}
