using System;
using System.Linq;
using System.Threading.Tasks;
using Booking.BussinesLogic.Handlers.GetHotelsList;
using Booking.DataLayer;
using Booking.DataLayer.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Booking.Views.Home
{
    public class GetHotelListPageModel : PageModel
    {
        private readonly BookingDbContext _dbContext;

        public GetHotelListPageModel(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SelectList Options { get; set; }
        public async Task OnGet()
        {
            var cities = await _dbContext.Cities
                .OnlyActive()
                .Select(x => x.Name)
                .ToArrayAsync();
            
            Options = new SelectList(cities);
        }
        
        public void OnPost()
        {

            var getHotelsListRequest = new GetHotelsListRequest()
            {
                City = Request.Form["city"],
                EndDate = DateTimeOffset.Parse(Request.Form["endDate"]),
                Seats = Int32.Parse(Request.Form["seats"]),
                StartDate = DateTimeOffset.Parse(Request.Form["startDate"]),
            };
            
            
            // do something with emailAddress
        }
    }
}