using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kyckling.Domain.Models
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }

        public bool Active { get; set; }

        public string ImageUrl { get; set; }

        public int MaxGuests { get; set; }

        public int DayCapacity { get; set; }

        public int MaxPersonsBooking { get; set; }

        public virtual List<OpenTime> OpenTimes { get; set; }

        public virtual List<CloseDate> ClosedDates { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public string Username { get; set; }

    }

    
  
    public class OpenTime
    {
        public int Id { get; set; }

        public Days Day { get; set; }

        public int OpeningTime { get; set; }

        public int ClosingTime { get; set; }
    }

    public class CloseDate
    {
        public int Id { get; set; }

        public DateTime ClosedDate { get; set; }
    }
}
 
 
