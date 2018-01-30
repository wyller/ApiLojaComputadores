using System;
using Dal.Model;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Dal.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Computador> Computador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;User Id=admin;Password=123456;Port=5432");
        }
    }
}