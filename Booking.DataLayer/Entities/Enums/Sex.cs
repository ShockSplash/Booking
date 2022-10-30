using System.ComponentModel.DataAnnotations;

namespace Booking.DataLayer.Entities.User
{
    public enum Sex
    {
        [Display(Name = "М")]
        Male = 1,
        
        [Display(Name = "Ж")]
        Female = 2
    }
}