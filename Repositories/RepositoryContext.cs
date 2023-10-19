using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
            Database.SetInitializer<RepositoryContext>(new DropCreateDatabaseIfModelChanges<RepositoryContext>());
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Figure> Figures { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<PositionatedModel> PositionatedModels { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Scene> Scenes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Username);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Figures)
                .WithRequired(f => f.FigureOwner)
                .HasForeignKey(f => f.FigureOwnerId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Materials)
                .WithRequired(m => m.MaterialOwner)
                .HasForeignKey(m => m.MaterialOwnerId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Models)
                .WithRequired(m => m.ModelOwner)
                .HasForeignKey(m => m.ModelOwnerId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Scenes)
                .WithRequired(s => s.SceneOwner)
                .HasForeignKey(s => s.SceneOwnerId);

            modelBuilder.Entity<Figure>()
                .HasKey(f => new { f.FigureName, f.FigureOwnerId });

            modelBuilder.Entity<Material>()
                .HasKey(ma => new { ma.MaterialName, ma.MaterialOwnerId });

            modelBuilder.Entity<Material>()
                .Ignore(m => m.Color);

            modelBuilder.Entity<LambertianMaterial>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("LambertianMaterials");
            });

            modelBuilder.Entity<MetalicMaterial>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("MetalicMaterials");
            });

            modelBuilder.Entity<Model>()
           .HasKey(mo => new { mo.ModelName, mo.ModelOwnerId });

            modelBuilder.Entity<Model>()
                .HasRequired(m => m.ModelFigure)
                .WithMany()
                .HasForeignKey(m => new { m.ModelFigureName, m.ModelFigureOwnerId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasRequired(m => m.ModelMaterial)
                .WithMany()
                .HasForeignKey(m => new { m.ModelMaterialName, m.ModelMaterialOwnerId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PositionatedModel>()
                .HasKey(p => p.PositionatedModelId);

            modelBuilder.Entity<PositionatedModel>()
                .HasRequired(p => p.BaseModel)
                .WithMany()
                .HasForeignKey(p => new { p.ModelName, p.ModelOwnerId })
                .WillCascadeOnDelete(false); ;

            modelBuilder.Entity<Scene>()
                .HasKey(s => new { s.SceneName, s.SceneOwnerId });
        }
    }
}
