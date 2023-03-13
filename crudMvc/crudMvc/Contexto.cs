using crudMvc.Controllers;
using crudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace crudMvc
{
    public class Contexto : DbContext
    {
        public DbSet<Cantor> Cantor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicaMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //public Contexto(DbContextOptions<Contexto> options) : base(options)
        //{

        //}    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cantor>().HasKey(c => c.Id);
        }


    }
    
    
   

}
