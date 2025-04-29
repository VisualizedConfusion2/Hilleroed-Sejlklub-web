using Hilleroed_Sejlklub_Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class BoatGridModel : PageModel
    {
        public void OnGet()
        {
            private readonly BoatService _bs;
        [BindProperty]
        public List<Boat> Boats {get;set;}
        public BoatGridModel(BoatService bs)
        {
            Boats = bs.GetAll();
        }
        }
    }
}
