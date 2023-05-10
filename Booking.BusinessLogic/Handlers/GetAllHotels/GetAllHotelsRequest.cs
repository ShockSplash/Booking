using System.Collections.Generic;
using Booking.Shared.Models;
using MediatR;

namespace Booking.BusinessLogic.Handlers.GetAllHotels
{
    public class GetAllHotelsRequest : IRequest<IEnumerable<HotelDtoModel>>
    {
        
    }
}