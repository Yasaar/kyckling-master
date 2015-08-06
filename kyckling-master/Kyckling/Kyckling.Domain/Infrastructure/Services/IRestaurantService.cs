using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public interface IRestaurantService
    {
        Restaurant GetRestaurant(string userName);

        Models.Restaurant GetRestaurant(int id);
        IEnumerable<Restaurant> GetRestaurantsBySearch(string search);
        IEnumerable<Restaurant> GetAllRestaurants(); 
        bool SaveRestaurant(Restaurant restaurant);
        bool UpdateRestaurant(Restaurant restaurant);
    }
}
