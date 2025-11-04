using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<ActualizarProducto> Actualizaciones => Set<ActualizarProducto>();
        public DbSet<EntradaProducto> Entradas => Set<EntradaProducto>();
        public DbSet<Factura> Facturas => Set<Factura>();
        public DbSet<DetalleFactura> DetallesFactura => Set<DetalleFactura>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente - La clave primaria es Ced_Cli (string)
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Ced_Cli);

            // Producto
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id_Pro);

            // ActualizarProducto
            modelBuilder.Entity<ActualizarProducto>()
                .HasKey(a => a.Id_Act_Pro);

            modelBuilder.Entity<ActualizarProducto>()
                .HasOne(a => a.Producto)
                .WithMany(p => p.Actualizaciones)
                .HasForeignKey(a => a.Id_Pro_Per)
                .OnDelete(DeleteBehavior.Restrict);

            // EntradaProducto
            modelBuilder.Entity<EntradaProducto>()
                .HasKey(e => e.Id_Ent_Pro);

            modelBuilder.Entity<EntradaProducto>()
                .HasOne(e => e.Producto)
                .WithMany(p => p.Entradas)
                .HasForeignKey(e => e.Id_Pro_Per)
                .OnDelete(DeleteBehavior.Restrict);

            // Factura
            modelBuilder.Entity<Factura>()
                .HasKey(f => f.Id_Fac);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.Ced_Cli_Per)
                .OnDelete(DeleteBehavior.Restrict);

            // DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasKey(d => d.Id_Det_Fac);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(d => d.Factura)
                .WithMany(f => f.Detalles)
                .HasForeignKey(d => d.Id_Fac_Per)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesFactura)
                .HasForeignKey(d => d.Id_Pro_Per)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleFactura>()
                .HasOne(d => d.Actualizacion)
                .WithMany()
                .HasForeignKey(d => d.Id_Act_Pro_Per)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar tipos de datos decimales
            modelBuilder.Entity<Producto>()
                .Property(p => p.Pre_Uni)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActualizarProducto>()
                .Property(a => a.Pre_Act_Pro)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.Tot_Fac)
                .HasColumnType("decimal(18,2)");
        }
    }
}