﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Lessee> Lessees { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}