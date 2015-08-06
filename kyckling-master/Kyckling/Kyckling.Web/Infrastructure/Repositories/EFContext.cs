using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Kyckling.Domain.Models;
using Kyckling.Web.Models;

namespace Kyckling.Web.Infrastructure.Repositories
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}