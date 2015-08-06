using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.WebUI.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbContext _context;

        public ReservationRepository()
        {
            _context = new EFContext();
        }
        public IEnumerable<ReservationModel> GetReservations(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationModel> GetReservations(DateTime reservationDate, int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationModel> GetReservations(string email)
        {
            throw new NotImplementedException();
        }

        public ReservationModel GetReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public ReservationModel SaveReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        public ReservationModel UpdateReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        public ReservationModel DeleteReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }
    }
}