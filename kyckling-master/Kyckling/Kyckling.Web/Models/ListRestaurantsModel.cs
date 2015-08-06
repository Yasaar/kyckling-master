using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kyckling.Web.Models
{
    public class ListRestaurantsModel
    {
        public ListRestaurantsModel()
        {
            Restaurants = new List<RestaurantModel>();
        }
        public List<RestaurantModel> Restaurants { get; set; }

    }
}