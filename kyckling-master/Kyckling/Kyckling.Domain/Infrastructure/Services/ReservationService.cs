using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public Restaurant GetRestaurant(int id)
        {
            return _repository.GetRestaurant(id);
        }

        public IEnumerable<Reservation> GetReservations(int restaurantId)
        {
            return _repository.GetReservations(restaurantId);
        }

        public IEnumerable<Reservation> GetReservations(int restaurantId, DateTime reservationDate)
        {
            return _repository.GetReservations(restaurantId, reservationDate);
        }

        public IEnumerable<Reservation> GetCustomerReservations(string email)
        {
            return _repository.GetCustomerReservations(email);
        }

        public IEnumerable<Reservation> GetRestaurantReservations(string username)
        {
            return _repository.GetRestaurantReservations(username);
        }

        public Reservation GetReservation(int reservationId)
        {
            if (reservationId >= 0)
            {
                return _repository.GetReservation(reservationId);                
            }
            return null;
        }

        public Reservation SaveReservation(Reservation reservation)
        {

            //Detta ska spara reservationen genom repository
            var res = _repository.SaveReservation(reservation);

            //Om repository returnerar något annat än null har det lyckats
            if (res != null)
            {
                var emailService = new EmailService();

                //Generera och skapa email
                emailService.Send(emailService.GenerateReservationConfirmation(reservation));
            }

            //Skicka tillbaka reservationen (för att kunna visa bekräftelse på skärmen t.ex.)
            return res;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            return _repository.UpdateReservation(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _repository.DeleteReservation(reservation);
        }

        public List<AvailableTime> GetAvailableTimes(int restaurantId, int personCount, DateTime date)
        {
            var restaurant = _repository.GetRestaurant(restaurantId); //Hämta aktuell Restaurang
            var reservations = _repository.GetReservations(restaurantId, date); //Hämta bokningar för aktuell Restaurang och aktuellt datum
            var openTime = restaurant.OpenTimes.Where(x => x.Day.ToString() == date.DayOfWeek.ToString()).FirstOrDefault(); //Kolla öppettider för restaurangen det aktuella datumet
            var timeList = new List<AvailableTime>();
            for (int i = openTime.OpeningTime; i < openTime.ClosingTime - 1; i++)
            {
                DateTime dateTime = date.Add(new TimeSpan(i, 0, 0));//Lägg till tid till datumet
                //int seats = GetAvailableSeats(restaurantId, dateTime);
                int seats = GetSeats(restaurant, reservations.ToList(), dateTime);
                if (seats >= personCount) timeList.Add(new AvailableTime() { FreeSeats = true, Hour = i, RestuarantModelId = restaurantId}); //Om personerna får plats sätt FreeSeats till true för den aktuella tiden
                else timeList.Add(new AvailableTime() { FreeSeats = false, Hour = i, RestuarantModelId = restaurantId }); //Om personerna inte får plats sätt FreeSeats till false för den aktuella tiden
            }
            return timeList;
        }

        public int GetAvailableSeats(int restaurantId, DateTime dateTime)
        {
            var restaurant = _repository.GetRestaurant(restaurantId); //Hämta aktuell Restaurang
            var reservations = _repository.GetReservations(restaurantId, dateTime); //Hämta bokningar för aktuell Restaurang och aktuellt datum
            var res = reservations.Where(x => x.TimeSlot.Hour == dateTime.Hour || x.TimeSlot.Hour - 1 == dateTime.Hour); //Kolla bokningar för aktuell tid
            var totalGuest = res.Sum(x => x.PersonCount);
            return (restaurant.MaxGuests - totalGuest);
        }

        private int GetSeats(Restaurant restaurant, IEnumerable<Reservation> reservations, DateTime dateTime)
        {
            var res = reservations.Where(x => x.TimeSlot.Hour == dateTime.Hour || x.TimeSlot.Hour - 1 == dateTime.Hour); //Kolla bokningar för aktuell tid
            var totalGuest = res.Sum(x => x.PersonCount);
            return (restaurant.MaxGuests - totalGuest);
            
        }
    }
}
