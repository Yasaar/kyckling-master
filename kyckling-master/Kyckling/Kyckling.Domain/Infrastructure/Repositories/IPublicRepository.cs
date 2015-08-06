using System;
using System.Collections.Generic;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Repositories
{
    public interface IPublicRepository
    {
        List<Restaurant> GetRestaurantsByCity(string city);
        List<Restaurant> GetRestaurntsByName(string name);
        List<Reservation> GetReservations(int restaurantId, DateTime date);
        Restaurant GetRestaurantModel(int restaurantId);
    }
}
