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
        [Display(Name = "Manufactor Year")]
        public int Year { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "License Plate Number")]
        public string? LicensePlate { get; set; }
        [Display(Name = "Make")]
        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }
        [Display(Name = "Color")]
        public int? ColorId { get; set; }
        public virtual Color? Color { get; set; }
        [Display(Name = "Model")]
        public int? CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }

    }
}
