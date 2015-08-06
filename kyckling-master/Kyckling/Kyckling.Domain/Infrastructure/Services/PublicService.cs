using System;
using System.Collections.Generic;
using System.Linq;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    class PublicService:IPublicService
    {
        private readonly IPublicRepository _repository;

        public PublicService(IPublicRepository repository)
        {
            _repository = repository;
        }
        
        public List<Models.Restaurant> GetRestaurantsByCity(string city)
        {
            return _repository.GetRestaurantsByCity(city);
        }

        public List<Models.Restaurant> GetRestaurantsByName(string name)
        {
            return _repository.GetRestaurntsByName(name);
        }

        public List<AvailableTime> GetAvailableTimes(int restaurantId, int personCount, DateTime date)
        {
            var restaurant = _repository.GetRestaurantModel(restaurantId); //Hämta aktuell Restaurang
            var reservations = _repository.GetReservations(restaurantId, date); //Hämta bokningar för aktuell Restaurang och aktuellt datum
            var openTime = restaurant.OpenTimes.Where(x=>x.Day.ToString()==date.DayOfWeek.ToString()).FirstOrDefault(); //Kolla öppettider för restaurangen det aktuella datumet
            var timeList = new List<AvailableTime>();
            for (int i = openTime.OpeningTime; i < openTime.ClosingTime-1; i++)
            {
                DateTime dateTime = date.Add(new TimeSpan(i, 0, 0));//Lägg till tid till datumet
                int seats=GetAvailableSeats(restaurantId, dateTime);
                if(seats>=personCount) timeList.Add(new AvailableTime(){FreeSeats = true,Hour = i}); //Om personerna får plats sätt FreeSeats till true för den aktuella tiden
                else timeList.Add(new AvailableTime() { FreeSeats = false, Hour = i }); //Om personerna inte får plats sätt FreeSeats till false för den aktuella tiden
            }
            return timeList;
        }

        public int GetAvailableSeats(int restaurantId, DateTime dateTime)
        {
            var restaurant = _repository.GetRestaurantModel(restaurantId); //Hämta aktuell Restaurang
            var reservations = _repository.GetReservations(restaurantId, dateTime); //Hämta bokningar för aktuell Restaurang och aktuellt datum
            var res = reservations.Where(x => x.TimeSlot.Hour == dateTime.Hour || x.TimeSlot.Hour - 1 == dateTime.Hour); //Kolla bokningar för aktuell tid
            var totalGuest = res.Sum(x => x.PersonCount);
            return (restaurant.MaxGuests - totalGuest); 
        }
    }
}
