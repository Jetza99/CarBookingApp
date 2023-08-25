using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name is Too Long")]
        public string Name { get; set; }

    }
}
