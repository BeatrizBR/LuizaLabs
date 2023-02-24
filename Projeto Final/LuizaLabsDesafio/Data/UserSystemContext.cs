using DesafioLuizaLabs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LuizaLabsDesafio.Data
{
    public class UserSystemContext : DbContext
    {
        public UserSystemContext(DbContextOptions<UserSystemContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
