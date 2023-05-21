using System;
using Booking.BusinessLogic.Handlers.GetInfoByRoom;
using Booking.Shared.Models;

namespace Booking.BusinessLogic.Handlers.Account.GetBookignsByUser
{
    public record GetBookingsByUserResponse
    {
        public HotelDtoModel Hotel { get; init; }

        public GetInfoByRoomResponse RoomInfo { get; init; }

        public DateTimeOffset StartDate { get; init; }

        public DateTimeOffset EndDate { get; init; }
    }
}