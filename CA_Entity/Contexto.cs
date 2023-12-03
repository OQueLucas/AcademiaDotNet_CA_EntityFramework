using CA_Entity.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CA_Entity
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["aulaentity"];

            //string retorno = "";

            //if (settings != null)
            //{
            //    retorno = settings.ConnectionString;
            //}

            //optionsBuilder.UseSqlServer(retorno);

            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = aulaentity; User ID = aulaentity; password = senha1234; language = Portuguese;");

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>()
                .HasOne(email => email.pessoa)
                .WithMany(pessoa => pessoa.Emails)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
