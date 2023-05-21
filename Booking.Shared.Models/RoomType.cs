using System.ComponentModel.DataAnnotations;

namespace Booking.Shared.Models
{
    public enum RoomType
    {
        [Display(Name = "Эконом")]
        Economy = 1,
        
        [Display(Name = "Комфорт")]
        Comfort = 2,
        
        [Display(Name = "Люкс")]
        Luxe = 3
    }
}