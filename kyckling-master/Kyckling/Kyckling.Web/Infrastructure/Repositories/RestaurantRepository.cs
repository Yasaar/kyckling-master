using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Kyckling.Domain;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Web.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly EFContext _context;

        public RestaurantRepository(EFContext context)
        {
            _context = context;
        }

        public Domain.Models.Restaurant GetRestaurant(string userName)
        {
            return _context.Restaurants.Single(r => r.Username == userName);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Domain.Models.Restaurant> GetRestaurantsByCity(string city)
        {
            return _context.Restaurants.Where(r => r.City.ToLower().Contains(city.ToLower())).ToList();
        }

        public IEnumerable<Domain.Models.Restaurant> GetRestaurantsByName(string name)
        {
            return _context.Restaurants.Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants;
        }

        public bool SaveRestaurant(Domain.Models.Restaurant restaurant)
        {
            var restaurants = _context.Restaurants;
            restaurants.Add(restaurant);
            _context.SaveChanges();
            if(restaurant.Id!=0)return true;
            else return false;
        }

        public bool UpdateRestaurant(Domain.Models.Restaurant restaurant)
        {
            var restauranto = _context.Restaurants.Single(r=>r.Id==restaurant.Id);
            if (restaurant.ImageUrl != null)
            {
                restauranto.ImageUrl = restaurant.ImageUrl;
            }
            restauranto.MaxGuests = restaurant.MaxGuests;
            restauranto.PostalCode = restaurant.PostalCode;
            if(restauranto.Reservations!=null)
            restauranto.Reservations = restauranto.Reservations.ToList();
            restauranto.StreetAddress = restaurant.StreetAddress;
            restauranto.City = restaurant.City;
            restauranto.Description = restaurant.Description;
            restauranto.Active = restaurant.Active;
            restauranto.MaxPersonsBooking = restaurant.MaxPersonsBooking;
            restauranto.DayCapacity = restaurant.DayCapacity;
            restauranto.Name = restaurant.Name;
            for (int i = 0; i < 7; i++)
            {
                restauranto.OpenTimes[i].OpeningTime = restaurant.OpenTimes[i].OpeningTime;
                restauranto.OpenTimes[i].ClosingTime = restaurant.OpenTimes[i].ClosingTime;
            }
            if(restauranto.ClosedDates==null) restauranto.ClosedDates=new List<CloseDate>();
            if (restauranto.ClosedDates.Count >0)
            {
                for(int i=restauranto.ClosedDates.Count-1;i>=0;i--)
                {
                    if (!restaurant.ClosedDates.Any(c => c.ClosedDate == restauranto.ClosedDates[i].ClosedDate))
                    {
                        restauranto.ClosedDates.Remove(restauranto.ClosedDates[i]);
                    }
                }
                foreach (var closedDate in restaurant.ClosedDates)
                {
                    if (!restauranto.ClosedDates.Any(c => c.ClosedDate == closedDate.ClosedDate))
                    {
                        restauranto.ClosedDates.Add(closedDate);
                    }
                }
            }
            _context.SaveChanges();

            if (restaurant.Id != 0) return true;
            else return false;
        }
    }
}