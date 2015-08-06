using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Repositories
{
    public interface IRestaurantRepository
    {
        Restaurant GetRestaurant(string userName);

        Models.Restaurant GetRestaurant(int id);
        IEnumerable<Restaurant> GetRestaurantsByCity(string city);
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        IEnumerable<Restaurant> GetAllRestaurants(); 
        bool SaveRestaurant(Restaurant restaurant);
        bool UpdateRestaurant(Restaurant restaurant);
    }
}
