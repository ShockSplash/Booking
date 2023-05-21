using System;

namespace Booking.BusinessLogic.Handlers.GetRoomsAggregate
{
    public class GetRoomsAggregateResponse
    {
        /// <summary>
        /// Инфа об отеле
        /// </summary>
        public HotelsResponseModel Hotel { get; set; }

        /// <summary>
        /// Комнаты
        /// </summary>
        public RoomsResponseUnit[] Rooms { get; set; }
    }

    public class HotelsResponseModel
    {
        /// <summary>
        /// Название отеля
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Id отеля
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ширина
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double? Longitude { get; set; }

        public string Description { get; set; }

        public int? Rate { get; set; }
    }

    public class RoomsResponseUnit
    {
        /// <summary>
        /// Id комнаты
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Количество мест
        /// </summary>
        public int Seats { get; set; }
        
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public string Type { get; set; }

        public string Description { get; set; }

        public double PricePerDay { get; set; }
    }
}