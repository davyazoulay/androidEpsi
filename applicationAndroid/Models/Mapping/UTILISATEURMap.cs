using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace applicationAndroid.Models.Mapping
{
    public class UTILISATEURMap : EntityTypeConfiguration<UTILISATEUR>
    {
        public UTILISATEURMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.login)
                .HasMaxLength(50);

            this.Property(t => t.mdp)
                .HasMaxLength(50);

            this.Property(t => t.nom)
                .HasMaxLength(50);

            this.Property(t => t.prenom)
                .HasMaxLength(50);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.pays)
                .HasMaxLength(50);

            this.Property(t => t.ville)
                .HasMaxLength(50);

            this.Property(t => t.code_postal)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UTILISATEUR");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.mdp).HasColumnName("mdp");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.prenom).HasColumnName("prenom");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.date_naissance).HasColumnName("date_naissance");
            this.Property(t => t.pays).HasColumnName("pays");
            this.Property(t => t.ville).HasColumnName("ville");
            this.Property(t => t.code_postal).HasColumnName("code_postal");

            // Relationships
            this.HasMany(t => t.UTILISATEUR1)
                .WithMany(t => t.UTILISATEURs)
                .Map(m =>
                    {
                        m.ToTable("ASSO_AMIS");
                        m.MapLeftKey("id_utilisateur1");
                        m.MapRightKey("id_utilisateur2");
                    });


        }
    }
}
