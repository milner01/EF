using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EFConsoleTutorial.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<TodoItem> todoItems { get; set; } = default!;
        public DbSet<Courses> courses { get; set; } = default!;
        public DbSet<Students> students { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=SchoolDB;Integrated Security=True");
        }
    }
}

