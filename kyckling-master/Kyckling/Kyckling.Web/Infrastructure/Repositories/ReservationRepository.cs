using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Web.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly EFContext _context;

        public ReservationRepository()
        {
            _context = new EFContext();
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Reservation> GetReservations(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetReservations(int restaurantId, DateTime reservationDate)
        {
            var reservations = _context.Reservations.Where(x => x.Restaurant.Id == restaurantId).ToList();
            var correctReservations = reservations.Where(x => x.TimeSlot.Date == reservationDate.Date);
            return correctReservations;
        }

        public IEnumerable<Reservation> GetCustomerReservations(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetRestaurantReservations(string username)
        {
            return _context.Reservations.Where(x => x.Restaurant.Username == username);
        }

        public IEnumerable<Reservation> GetReservations(string email)
        {
            return _context.Reservations.Where(x => x.Email == email);
        }

        public Reservation GetReservation(int reservationId)
        {
            return _context.Reservations.FirstOrDefault(x => x.Id == reservationId);
        }

        public Reservation SaveReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return
                _context.Reservations.FirstOrDefault(
                    x => x.TimeSlot == reservation.TimeSlot && x.Email == reservation.Email);
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return null;
        }
    }
}