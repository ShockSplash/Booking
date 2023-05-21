using System;
using Booking.Shared.Models;
using Newtonsoft.Json;

namespace BlazorClient.ClientModels
{
    public class GetBookingsByUserResponse
    {
        public HotelDtoModel Hotel { get; set; }

        public GetInfoByRoomResponse RoomInfo { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        [JsonIgnore]
        public string BeginDateNormalized =>
            StartDate.ToString("yyyy-MM-dd");
        
        [JsonIgnore]
        public string EndDateNormalized =>
            EndDate.ToString("yyyy-MM-dd");
    }
}