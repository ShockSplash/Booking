using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using MediatR;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public class GetHotelsListRequestHandler : IRequestHandler<GetHotelsListRequest, List<GetHotelsListResponse>>
    {
        //private readonly BookingDbContext _dbContext;

        public GetHotelsListRequestHandler()
        {
           // _dbContext = dbContext;
        }

        public async Task<List<GetHotelsListResponse>> Handle(GetHotelsListRequest request, CancellationToken cancellationToken)
        {
            var s = 5;
            Console.WriteLine("Dbug");
            
            return null!;
        }
    }
}