using System;
using System.Collections.Generic;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    internal interface IPublicService
    {
        List<Restaurant> GetRestaurantsByCity(string city);
        List<Restaurant> GetRestaurantsByName(string name);
        List<AvailableTime> GetAvailableTimes(int restaurantId, int numberOfPersons, DateTime date);
        int GetAvailableSeats(int restaurantId, DateTime dateTime);
    }
}
