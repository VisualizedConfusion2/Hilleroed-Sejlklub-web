using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hilleroed_Sejlklub_Library.Interfaces;
using Hilleroed_Sejlklub_Library.Models;
using Hilleroed_Sejlklub_Library.Services;
using Hilleroed_Sejlklub_Library.Repos;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class BookingGridModel : PageModel
    {
        private readonly BoatRepo _boatRepo;

        public BookingGridModel(BoatRepo boatRepo)
        {
            _boatRepo = boatRepo;
        }
        public List<Boat> Get()
        {
            return _boatRepo.Get();
        }
        public void OnGet()
        {
        }
    }
}
