using Booking.Shared.Models;

namespace BlazorClient.ClientModels
{
    public class GetHotelsListResponse
    {
        public HotelDtoModel[] Hotels { get; set; }
    }
}