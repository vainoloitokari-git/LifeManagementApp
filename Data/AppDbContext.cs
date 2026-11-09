using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Models;

namespace LifeManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
