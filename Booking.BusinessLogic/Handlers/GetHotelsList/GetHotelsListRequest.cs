using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Booking.DataLayer.Entities;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public record GetHotelsListRequest : IRequest<List<GetHotelsListResponse>>
    {
        [Required]
        public string City { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Seats { get; set; }

        public string Type { get; set; }
    }
}