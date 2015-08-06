using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Kyckling.Domain.Models;

namespace Kyckling.Web.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int PersonCount { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime TimeSlot { get; set; }
    }

    public class SelectDateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfPersons { get; set; }
        public SelectList PersonCountList { get; set; }
    }
    public class CreateReservationModel
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string Telephone { get; set; }
        [Display(Name = "Ditt namn")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Antal personer")]
        public int PersonCount { get; set; }
        public DateTime TimeSlot { get; set; }
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Display(Name = "Klockslag")]
        public int Time { get; set; }
        public List<AvailableTime> AvailableTimes { get; set; }
        public SelectList TimeSelectList { get; set; }

    }

    public class CancelReservationModel
    {
        public int BookingId { get; set; }
        public string Email { get; set; }
        [Display(Name = "Meddelande")]
        public string Message { get; set; }
        [Display(Name = "Skicka avboknings mail till gäst")]
        public bool SendMail { get; set; }

    }

    public class ListReservationsModel
    {
        public ListReservationsModel(string username, IEnumerable<Reservation> reservations)
        {
            Reservations = new List<ReservationModel>();

            if (reservations != null)
            {
                foreach (var r in reservations.ToList())
                {
                    Reservations.Add(new ReservationModel()
                    {
                        Id = r.Id,
                        PersonCount = r.PersonCount,
                        Restaurant = r.Restaurant,
                        TimeSlot = r.TimeSlot,
                        Name = r.Name,
                        Email = r.Email
                    });
                }
            }

        }

        public string Username { get; set; }
        public List<ReservationModel> Reservations { get; set; }

        [DisplayName("Från: ")]
        public DateTime FromDate { get; set; }

        [DisplayName("Till: ")]
        public DateTime ToDate { get; set; }
        
        [DisplayName("Visa: ")]
        public SelectList DateSpan { get; set; }
        public int TotalReservations
        {
            get { return Reservations.Count(); }
        }
    }

    public class ErrorViewModel
    {
        public int RestaurantId { get; set; }
        public string Message { get; set; }
    }
}