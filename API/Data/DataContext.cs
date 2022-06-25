using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

// namespace matches the name of the folder that this file lives in
namespace API.Data
{
    // DbContext -> "using Microsoft.EntityFrameworkCore;"
    public class DataContext : DbContext
    {
        // This is a constructor method
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet<AppUser> -> using API.Entities;
        public DbSet<AppUser> Users { get; set; }
    }
}