using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kyckling.Domain.Models;

namespace Kyckling.WebUI.Infrastructure.Repositories
{
    public class EFContext : DbContext
    {
        public DbSet<RestaurantModel> Restaurants { get; set; }
    }
}