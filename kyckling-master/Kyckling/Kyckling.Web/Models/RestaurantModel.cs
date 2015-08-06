using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Kyckling.Domain.Models;

namespace Kyckling.Web.Models
{
    public class RestaurantModel
    {
        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Gatuadress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postnummer")]
        public string PostalCode { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }

        
        [DataType(DataType.EmailAddress),Display(Name = "Epost")]
        public string Email { get; set; }
        
        public bool Active { get; set; }
        
        [Required,Range(1,1000),Display(Name = "Maximalt antal sittplatser")]
        public int MaxGuests { get; set; }

        [Display(Name = "Bild fil")]
        public HttpPostedFileBase Image { get; set; }

        public List<OpenTime> OpenTimes { get; set; }

        public string ImageUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "Maximal kapacitet per dag")]
        public int DayCapacity { get; set; }

        [Display(Name = "Maximalt antal personer per bokning")]
        public int MaxPersonsBooking { get; set; }

        public string ClosedDates { get; set; }
    }

    public class CreateRestaurantModel
    {
        public string Username { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "Epost")]
        public string Email { get; set; }

        [Display(Name = "Namn på restaurangen")]
        public string RestaurantName { get; set; }
    }
}