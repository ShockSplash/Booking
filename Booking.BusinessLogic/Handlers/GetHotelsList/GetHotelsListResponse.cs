using Booking.Shared.Models;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public record GetHotelsListResponse
    {
        public HotelDtoModel[] Hotels { get; set; }
    }
}