using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyckling.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonCount { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime TimeSlot { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
