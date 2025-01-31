using Microsoft.EntityFrameworkCore;
using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<ClienteModel> Tab_Cliente { get; set; }
        public DbSet<PedidoModel> Tab_Pedido { get; set; }
        public DbSet<PedidoItemModel> Tab_Pedido_Item { get; set; }
        public DbSet<ProdutoModel> Tab_Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoItemModel>()
                .HasKey(pi => new { pi.Cod_Pedido, pi.Cod_Produto });

            modelBuilder.Entity<PedidoItemModel>()
                .HasOne(pi => pi.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(pi => pi.Cod_Pedido);

            modelBuilder.Entity<PedidoItemModel>()
                .HasOne(pi => pi.Produto)
                .WithMany()
                .HasForeignKey(pi => pi.Cod_Produto);

            // Definição das propriedades decimal 
            modelBuilder.Entity<PedidoItemModel>()
                .Property(pi => pi.Val_PrecoUnitario)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoItemModel>()
                .Property(pi => pi.Val_TotalItem)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PedidoModel>()
                .Property(p => p.Val_Pedido)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ProdutoModel>()
                .Property(p => p.Val_Preco)
                .HasPrecision(18, 4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
