using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class E1AppContext : DbContext
{
        public E1AppContext(DbContextOptions options) : base(options)
        {
        }

             public DbSet<User> Users { get; set; }
             public DbSet<Rol>  Rols { get; set; }
             public DbSet<UserRol> UsersRols { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}