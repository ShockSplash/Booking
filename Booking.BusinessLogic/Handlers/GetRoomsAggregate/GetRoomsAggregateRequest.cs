using System;
using Booking.BusinessLogic.Handlers.GetRoomsAggregate;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetRoomsAggregate
{
    public class GetRoomsAggregateRequest : Shared.Models.GetRoomsAggregateRequest, IRequest<GetRoomsAggregateResponse>
    {
        public Guid HotelId { get; set; }
    }
}