using System;
using System.Collections.Generic;
using firstApiTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace firstApiTask.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

    }
}

