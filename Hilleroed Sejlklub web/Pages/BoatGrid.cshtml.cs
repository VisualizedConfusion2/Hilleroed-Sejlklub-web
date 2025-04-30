using Hilleroed_Sejlklub_Library;
using Hilleroed_Sejlklub_Library.Models;
using Hilleroed_Sejlklub_Library.Repos;
using Hilleroed_Sejlklub_Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class BoatGridModel : PageModel
    {
        private BoatService _bs;
        [BindProperty]
        public List<Boat> Boats { get; set; }


        public BoatGridModel(BoatService bs)
        {
            _bs = bs;
            Boats = bs.Get();
        }

        //Logic for OnGet can be added here if needed
        public void OnGet()
        {

        }
    } //Ensure this closing brace matches the class definition  
}
