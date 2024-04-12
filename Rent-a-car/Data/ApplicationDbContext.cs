using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Rent_a_car.Models;

namespace Rent_a_car.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rent_a_car.Models.Car> Car { get; set; }
        public DbSet<Rent_a_car.Models.Query> Query { get; set; }
    }
}
