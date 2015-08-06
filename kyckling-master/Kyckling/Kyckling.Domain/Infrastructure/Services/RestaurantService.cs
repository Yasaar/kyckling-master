using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public class RestaurantService:IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public Models.Restaurant GetRestaurant(string userName)
        {
            return _repository.GetRestaurant(userName);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _repository.GetRestaurant(id);
        }

        public IEnumerable<Models.Restaurant> GetRestaurantsBySearch(string search)
        {
            var restaurantsName = _repository.GetRestaurantsByName(search);
            var restaurantsCity = _repository.GetRestaurantsByCity(search);
            return restaurantsName.Concat(restaurantsCity).Distinct().Where(r=>r.Active==true);
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _repository.GetAllRestaurants();
        }

        public bool SaveRestaurant(Models.Restaurant restaurant)
        {
            return _repository.SaveRestaurant(restaurant);
        }

        public bool UpdateRestaurant(Models.Restaurant restaurant)
        {
            return _repository.UpdateRestaurant(restaurant);
        }
    }  
}
