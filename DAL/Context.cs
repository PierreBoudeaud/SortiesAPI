using BO;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class Context: DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Excursion> Excursions { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Weather> Weathers { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Excursion>()
                .HasOne(a => a.Activity)
                .WithMany(a => a.Excursions)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonsExcursions>().HasKey(pe => new {pe.ExcursionId, pe.PersonId});

            modelBuilder.Entity<PersonsExcursions>()
                .HasOne(pe => pe.Excursion)
                .WithMany(e => e.SubscribePeople)
                .HasForeignKey(pe => pe.ExcursionId);

            modelBuilder.Entity<PersonsExcursions>()
                .HasOne(pe => pe.Person)
                .WithMany(p => p.SubExcursions)
                .HasForeignKey(pe => pe.PersonId);

            modelBuilder.Entity<Excursion>()
                .HasOne(e => e.Creator)
                .WithMany();

            modelBuilder.Entity<Excursion>()
                .HasOne(e => e.Weather)
                .WithOne(w => w.Excursion)
                .HasForeignKey<Weather>(w => w.ExcursionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
