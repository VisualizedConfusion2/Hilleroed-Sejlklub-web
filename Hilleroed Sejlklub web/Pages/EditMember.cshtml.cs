using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hilleroed_Sejlklub_Library.Models;
using System.Text.Json;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class EditMemberModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string ContactInfo { get; set; }

        [BindProperty]
        public DateTime BirthDay { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        private string filePathJson;

        // Constructor to initialize the file path for the json
        public EditMemberModel(IWebHostEnvironment e)
        {
            filePathJson = Path.Combine(e.ContentRootPath, "json1.json");
        }
        public void OnGet()
        {}

        public IActionResult OnPost()
        {
            // Create new member using the default constructor
            var newMember = new Member
            {
                Name = Name,
                ContactInfo = ContactInfo,
                Birthday = BirthDay,
                Gender = Gender
            };

            List<Member> members = new List<Member>();

            // Check if the file exists and read existing members
            if (System.IO.File.Exists(filePathJson))
            {
                var existingJson = System.IO.File.ReadAllText(filePathJson);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    members = JsonSerializer.Deserialize<List<Member>>(existingJson) ?? new List<Member>();
                }
            }

            // Add the new member to the list
            members.Add(newMember);

            // Serialize the updated list and write it back to the file
            var updatedJson = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePathJson, updatedJson);

            return Page();
        }
    }
}
