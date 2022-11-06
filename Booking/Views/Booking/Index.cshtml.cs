using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking.Views.Booking
{
    public class Index : PageModel
    {
        public void OnGet()
        {
            
        }
        
        public void OnPost()
        {
            var emailAddress = Request.Form["emailaddress"];
            // do something with emailAddress
        }
    }
}