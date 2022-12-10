using EvoSystemWebAPI.Data.Map;
using EvoSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoSystemWebAPI.Data
{
    public class DepartamentoContext : DbContext
    {
        public DbSet<DepartamentoModel> ?Departamentos { get; set; }
        public DbSet<FuncionarioModel> ?Funcionarios { get; set; }

        public DepartamentoContext(DbContextOptions<DepartamentoContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=Thamires10.;Persist Security Info=True;User ID=rafael02;Initial Catalog=EvoSystem;Data Source=DESKTOP-OIPJ5O5\\SQLEXPRESS\r\n");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartamentoMap());
            //modelBuilder.ApplyConfiguration(new FuncionarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
