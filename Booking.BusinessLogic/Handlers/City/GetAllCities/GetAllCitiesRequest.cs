using MediatR;

namespace Booking.BussinesLogic.Handlers.City.GetAllCities
{
    public record GetAllCitiesRequest : IRequest<string[]>
    {
        
    }
}