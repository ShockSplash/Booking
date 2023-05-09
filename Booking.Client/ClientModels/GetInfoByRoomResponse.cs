namespace BlazorClient.ClientModels
{
    public class GetInfoByRoomResponse
    {
        public string City { get; set; }

        public int Seats { get; set; }

        public double PricePerDay { get; set; }

        public string HotelName { get; set; }

        public string RoomDescription { get; set; }
    }
}