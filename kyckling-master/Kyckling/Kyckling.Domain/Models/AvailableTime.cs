using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyckling.Domain.Models
{
    public class AvailableTime
    {
        public int RestuarantModelId { get; set; } 
        public int Hour { get; set; }
        public bool FreeSeats { get; set; }
    }
}
