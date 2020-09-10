using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewHackhaThon.Models;

namespace NewHackhaThon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Students> Student { get; set; }
        public DbSet<Pupils> Pupil { get; set; }
        public DbSet<Profiles> Profile { get; set; }

      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<Students>().HasKey(m => m.StudentsId);
            builder.Entity<Pupils>().HasKey(m => m.PupilsId);
            builder.Entity<Profiles>().HasKey(m => m.ProfilesId);
            base.OnModelCreating(builder);
        }
    }
}
