using Hilleroed_Sejlklub_Library.Models;
using Hilleroed_Sejlklub_Library.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class EditBookingModel : PageModel
    {
        public List<Booking>? Bookings { get; set; }

        public void OnGet()
        {
            
        }
    }
}
