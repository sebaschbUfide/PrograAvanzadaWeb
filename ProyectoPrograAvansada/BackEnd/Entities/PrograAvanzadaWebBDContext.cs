using System;
using BackEnd.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Entities
{
    public partial class PrograAvanzadaWebBDContext : IdentityDbContext<ApplicationUser>
    {
        public PrograAvanzadaWebBDContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PrograAvanzadaWebBDContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
        }

        public PrograAvanzadaWebBDContext(DbContextOptions<PrograAvanzadaWebBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaProd> CategoriaProds { get; set; }
        public virtual DbSet<Cotizacion> Cotizacions { get; set; }
        public virtual DbSet<Envio> Envios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CategoriaProd>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__C928AD52D8E97F92");

                entity.ToTable("Categoria_prod");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_id");

                entity.Property(e => e.CategoriaName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Categoria_name");

                entity.Property(e => e.ProdId).HasColumnName("Prod_id");

                entity.Property(e => e.ProvId).HasColumnName("prov_id");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.CategoriaProds)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categoria__Prod___34C8D9D1");

                entity.HasOne(d => d.Prov)
                    .WithMany(p => p.CategoriaProds)
                    .HasForeignKey(d => d.ProvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categoria__prov___35BCFE0A");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.ContizacionId)
                    .HasName("PK__Cotizaci__791E8F1CD2D6EF4E");

                entity.ToTable("Cotizacion");

                entity.Property(e => e.ContizacionId).HasColumnName("contizacion_id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.ClienteName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cliente_name");

                entity.Property(e => e.ProdId).HasColumnName("Prod_id");

                entity.Property(e => e.ProducName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("produc_name");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__clien__2E1BDC42");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Prod___2D27B809");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.ToTable("Envio");

                entity.Property(e => e.EnvioId).HasColumnName("Envio_id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.ContizacionId).HasColumnName("contizacion_id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Envio__cliente_i__30F848ED");

                entity.HasOne(d => d.Contizacion)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ContizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Envio__contizaci__31EC6D26");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Producto__C55AC32BF556F7E2");

                entity.ToTable("Producto");

                entity.Property(e => e.ProdId).HasColumnName("Prod_id");

                entity.Property(e => e.ProdDescrip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Prod_descrip");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Prod_name");

                entity.Property(e => e.ProdPrecio)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("Prod_precio");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.ProvId)
                    .HasName("PK__Proveedo__435F5326B5D32F81");

                entity.ToTable("Proveedor");

                entity.Property(e => e.ProvId).HasColumnName("prov_id");

                entity.Property(e => e.ProvName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prov_name");

                entity.Property(e => e.ProvTel)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("prov_tel");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Registro__47E34D643429E5FE");

                entity.ToTable("Registro");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("cliente_id");

                entity.Property(e => e.ClienteEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cliente_Email");

                entity.Property(e => e.ClienteName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cliente_name");

                entity.Property(e => e.ClientePassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cliente_password");

                entity.Property(e => e.RolId).HasColumnName("Rol_id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registro__Rol_id__267ABA7A");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.RolId).HasColumnName("Rol_id");

                entity.Property(e => e.RolName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("rol_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
