using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Repositories
{
    public interface IReservationRepository
    {
        Restaurant GetRestaurant(int id);
        IEnumerable<Reservation> GetReservations(int restaurantId);
        IEnumerable<Reservation> GetReservations(int restaurantId, DateTime reservationDate);
        IEnumerable<Reservation> GetCustomerReservations(string email);
        IEnumerable<Reservation> GetRestaurantReservations(string username);
        Reservation GetReservation(int reservationId);
        Reservation SaveReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservation(Reservation reservation);
    }
}
