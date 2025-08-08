using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureEntities(modelBuilder);
            SeedData(modelBuilder);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasMany(u => u.Comandas)
                      .WithOne(c => c.Usuario)
                      .HasForeignKey(c => c.UsuarioId);
            });

            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.HasOne(c => c.Usuario)
                      .WithMany(u => u.Comandas)
                      .HasForeignKey(c => c.UsuarioId);

                entity.HasMany(c => c.Produtos)
                      .WithOne(p => p.Comanda)
                      .HasForeignKey(p => p.ComandaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasOne(p => p.Comanda)
                      .WithMany(c => c.Produtos)
                      .HasForeignKey(p => p.ComandaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var usuarios = new[]
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "João Silva",
                    Telefone = "47988887777",
                    Email = "joao.silva@email.com",
                    Senha = "admin123"
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Maria Santos",
                    Telefone = "47999998888",
                    Email = "maria.santos@email.com",
                    Senha = "admin123"
                },
                new Usuario
                {
                    Id = 3,
                    Nome = "Pedro Oliveira",
                    Telefone = "47977776666",
                    Email = "pedro.oliveira@email.com",
                    Senha = "admin123"
                },
                new Usuario
                {
                    Id = 4,
                    Nome = "Ana Costa",
                    Telefone = "47966665555",
                    Email = "ana.costa@email.com",
                    Senha = "admin123"
                },
                new Usuario
                {
                    Id = 5,
                    Nome = "Carlos Mendes",
                    Telefone = "47955554444",
                    Email = "carlos.mendes@email.com",
                    Senha = "admin123" 
                }
            };
            modelBuilder.Entity<Usuario>().HasData(usuarios);

            var comandas = new[]
            {
                new Comanda
                {
                    Id = 1,
                    UsuarioId = 1,
                },
                new Comanda
                {
                    Id = 2,
                    UsuarioId = 2,
                },
                new Comanda
                {
                    Id = 3,
                    UsuarioId = 3,
                },
                new Comanda
                {
                    Id = 4,
                    UsuarioId = 1,
                },
                new Comanda
                {
                    Id = 5,
                    UsuarioId = 4,
                }
            };
            modelBuilder.Entity<Comanda>().HasData(comandas);

            var produtos = new[]
            {
                new Produto
                {
                    Id = 1,
                    Nome = "X-Salada",
                    Preco = 30.00m,
                    ComandaId = 1
                },
                new Produto
                {
                    Id = 2,
                    Nome = "X-Bacon",
                    Preco = 35.00m,
                    ComandaId = 1
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Pizza Margherita",
                    Preco = 45.00m,
                    ComandaId = 2
                },

                new Produto
                {
                    Id = 4,
                    Nome = "X-Tudo",
                    Preco = 42.50m,
                    ComandaId = 3
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Batata Frita Grande",
                    Preco = 25.00m,
                    ComandaId = 3
                },
                new Produto
                {
                    Id = 6,
                    Nome = "Refrigerante 2L",
                    Preco = 22.00m,
                    ComandaId = 3
                },
                new Produto
                {
                    Id = 7,
                    Nome = "Hot Dog Especial",
                    Preco = 18.50m,
                    ComandaId = 4
                },
                new Produto
                {
                    Id = 8,
                    Nome = "Suco Natural",
                    Preco = 14.00m,
                    ComandaId = 4
                },
                new Produto
                {
                    Id = 9,
                    Nome = "Pizza Portuguesa",
                    Preco = 48.00m,
                    ComandaId = 5
                },
                new Produto
                {
                    Id = 10,
                    Nome = "Guaraná Lata",
                    Preco = 8.00m,
                    ComandaId = 5
                },
                new Produto
                {
                    Id = 11,
                    Nome = "Sobremesa Pudim",
                    Preco = 22.00m,
                    ComandaId = 5
                }
            };
            modelBuilder.Entity<Produto>().HasData(produtos);
        }
    }
}
