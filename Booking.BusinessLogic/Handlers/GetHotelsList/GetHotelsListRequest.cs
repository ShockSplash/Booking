using System;
using Booking.Shared.Models;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public class GetHotelsListRequest : GetHotelsListClientRequest, IRequest<GetHotelsListResponse>
    {
    }
}