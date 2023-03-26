using System.Collections.Generic;
using Booking.Shared.Models;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public class GetHotelsListRequest : GetHotelsListClientRequest, IRequest<List<GetHotelsListResponse>>
    {
    }
}