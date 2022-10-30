using Booking.DataLayer.Entities;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public record GetHotelsListResponse
    {
        public Hotel Hotel { get; init; }
        
        public Room Room { get; init; }
        
        public string BeginDate { get; init; }
        
        public string EndDate { get; init; }
        
        public int Seats { get; init; }
    }
}