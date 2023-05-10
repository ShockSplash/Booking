using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using Booking.DataLayer.Extensions;
using Booking.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLogic.Handlers.GetAllHotels
{
    public class GetAllHotelsRequestHandler : IRequestHandler<GetAllHotelsRequest, IEnumerable<HotelDtoModel>>
    {
        private readonly BookingDbContext _dbContext;

        public GetAllHotelsRequestHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HotelDtoModel>> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
        {
            return await _dbContext.Hotels
                .OnlyActive()
                .Select(x => new HotelDtoModel()
                {
                    Rate = x.Rate,
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    HotelCity = x.City.Name
                }).ToArrayAsync(cancellationToken);
        }
    }
}