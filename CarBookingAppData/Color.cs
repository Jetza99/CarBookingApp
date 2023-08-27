using System.ComponentModel.DataAnnotations;

namespace CarBookingAppData
{
    public class Color : BaseDomainEntity
    {
        [Display(Name = "Color")]
        public string? Name { get; set; }
        public virtual List<Car>? Cars { get; set; }
    }
}