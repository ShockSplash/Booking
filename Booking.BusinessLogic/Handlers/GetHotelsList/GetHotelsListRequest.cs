using System;
using System.Collections.Generic;
using Booking.DataLayer.Entities;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public record GetHotelsListRequest : IRequest<List<GetHotelsListResponse>>
    {
        public string City { get; init; }

        public DateTimeOffset StartDate { get; init; }

        public DateTimeOffset EndDate { get; init; }

        public int Seats { get; init; }

        public RoomType Type { get; init; }
    }
}