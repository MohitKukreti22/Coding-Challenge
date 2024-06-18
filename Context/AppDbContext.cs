using System;
using Coding_Challenge.Models;

using Microsoft.EntityFrameworkCore;

namespace Coding_Challenge.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event>Events { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}
