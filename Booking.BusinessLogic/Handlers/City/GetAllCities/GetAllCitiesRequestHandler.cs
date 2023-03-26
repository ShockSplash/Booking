using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using Booking.DataLayer.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.BussinesLogic.Handlers.City.GetAllCities
{
    public class GetAllCitiesRequestHandler : IRequestHandler<GetAllCitiesRequest, string[]>
    {
        private readonly BookingDbContext _dbContext;

        public GetAllCitiesRequestHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string[]> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
            => await _dbContext.Cities
                .OnlyActive()
                .Select(x => x.Name)
                .ToArrayAsync(cancellationToken);
    }
}