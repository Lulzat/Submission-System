using MarkelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkelApp.Data
{
    // ApplicationDbContext : Inherits from EFCore DbContext
    public class ApplicationDbContext : DbContext
    {
        // ctor -> Create Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Analysis> Analysis { get; set; }



    }
}
