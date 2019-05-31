using Computador.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Computador
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setor>().HasKey(t => t.Id);
            modelBuilder.Entity<Setor>().HasMany(t => t.Maquinas).WithOne(dt => dt.Setor);

            modelBuilder.Entity<Maquina>().HasKey(t => t.Id);
            modelBuilder.Entity<Maquina>().HasOne(t => t.Setor);

        }

        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Setor> Setor { get; set; }

    }
}
