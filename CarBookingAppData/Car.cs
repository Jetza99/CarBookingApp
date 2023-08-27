using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public class Car : BaseDomainEntity
    {

        [Required]
        [Range(1930, 2023)]
        public int Year { get; set; }
        [Required]
        [StringLength(10)]
        public string? LicensePlate { get; set; }
        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }
        public int? ColorId { get; set; }
        public virtual Color? Color { get; set; }
        public int? CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }

    }
}
