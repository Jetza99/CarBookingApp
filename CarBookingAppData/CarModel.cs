using System.ComponentModel.DataAnnotations;

namespace CarBookingAppData
{
    public class CarModel : BaseDomainEntity
    {
        [Display(Name = "Model")]
        public string? Name { get; set; }
        public int? MakeId { get; set; }
        [Display(Name = "Make")]
        public virtual Make? Make { get; set; }
        public virtual List<Car>? Cars { get; set; }
    }
}