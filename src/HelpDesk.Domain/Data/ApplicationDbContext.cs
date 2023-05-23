using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Domain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LocalUsers> localUsersDb { get; set; }
        public DbSet<User> usersDB { get; set; }
        public DbSet<Admin> adminDB { get; set; }
        public DbSet<Worker> workerDB { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId= 1,
                    Name = "Shanu Kumar",
                    Email = "shanu@gmail.com",
                    Password="shanu548115@",
                    ConfirmPassword="shanu548115@",
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                },
                new Admin
                {
                    AdminId= 2,
                    Name = "Siddhant Kashyap",
                    Email = "sid@gmail.com",
                    Password = "sid@",
                    ConfirmPassword = "sid@",
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                }
                );
        }
    }
}
