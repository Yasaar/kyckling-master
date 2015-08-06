using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public interface IReservationService
    {
        int GetAvailableSeats(int restaurantId, DateTime dateTime);
        List<AvailableTime> GetAvailableTimes(int restaurantId, int personCount, DateTime date);
        Restaurant GetRestaurant(int id);

        /// <summary>
        /// Returnerar en IEnumerable med reservationer för en viss restaurant (dvs alla bokningar)
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        IEnumerable<Reservation> GetReservations(int restaurantId);

        /// <summary>
        /// Returnerar en IEnumerable med reservationer för en viss restaurant en viss dag
        /// </summary>
        /// <param name="reservationDate"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        IEnumerable<Reservation> GetReservations(int restaurantId, DateTime reservationDate);

        /// <summary>
        /// Returnerar en IEnumerable med reservationer för en viss e-mailadress (kund)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IEnumerable<Reservation> GetCustomerReservations(string email);

        /// <summary>
        /// Returnerar en IEnumerable med reservationer för en inloggad användare (restaurant)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IEnumerable<Reservation> GetRestaurantReservations(string username);
        
        
        /// <summary>
        /// Returnerar en ReservationModel för ett visst reservationId
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        Reservation GetReservation(int reservationId);

        /// <summary>
        /// Spara en ny Reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        Reservation SaveReservation(Reservation reservation);

        /// <summary>
        /// Uppdatera en befintlig reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        Reservation UpdateReservation(Reservation reservation);

        /// <summary>
        /// Ta bort en reservation helt (avboka)
        /// </summary>
        /// <param name="reservation"></param>
        void DeleteReservation(Reservation reservation);
    }
}
