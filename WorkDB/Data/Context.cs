using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDB.Model;

namespace WorkDB.Data
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Case> Case { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().HasKey(p => p.Id);
            //modelBuilder.Entity<Contact>().HasKey(p => p.Id);
            //modelBuilder.Entity<Case>().HasKey(p => p.Id);
        }
    }
}
