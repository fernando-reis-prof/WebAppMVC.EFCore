using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.EFCore.Models
{
    public class EFContext : DbContext
    {
        private string connectionString;

        public EFContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<Aluno>? Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .ToTable("Alunos")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Aluno>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
                
            modelBuilder.Entity<Aluno>()
                .Property(p => p.Nome)
                .HasColumnType("VARCHAR(80)")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(p => p.SobreNome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Aluno>()
                .Property(p => p.DataNascimento)
                .HasColumnType("datetime");
        }

    }
}
