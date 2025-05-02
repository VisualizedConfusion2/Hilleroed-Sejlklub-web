using Hilleroed_Sejlklub_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Text.Json;

namespace Hilleroed_Sejlklub_web.Pages
{
    public class MemberGridModel : PageModel
    {
    
            public List<Member> Members { get; set; } = new();

            private readonly string memberFilePathJson;

            public MemberGridModel(IWebHostEnvironment environment)
            {
                memberFilePathJson = Path.Combine(environment.ContentRootPath, "MemberData.json");
                Debug.WriteLine($"Boat file path: {memberFilePathJson}"); // Log the file path for debugging
            }
            public void OnGet()
            {
                Debug.WriteLine("OnGet method started.");

                // Check if the file exists
                Debug.WriteLine($"Checking if file exists: {memberFilePathJson}");
                if (System.IO.File.Exists(memberFilePathJson))
                {
                    Debug.WriteLine("File found. Reading content...");
                    var json = System.IO.File.ReadAllText(memberFilePathJson);

                    // Log the content of the file (optional, avoid for large files)
                    Debug.WriteLine($"File content: {json}");

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            // Attempt to deserialize the JSON
                            Debug.WriteLine("Deserializing JSON...");
                            Members = JsonSerializer.Deserialize<List<Member>>(json) ?? new();
                            Debug.WriteLine($"Deserialization successful. Loaded {Members.Count} boats.");
                        }
                        catch (Exception ex)
                        {
                            // Log the exception
                            Debug.WriteLine($"Error deserializing JSON: {ex.Message}");
                            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                            Members = new();
                        }
                    }
                    else
                    {
                        Debug.WriteLine("File content is empty or whitespace.");
                        Members = new();
                    }
                }
                else
                {
                    Debug.WriteLine("File not found.");
                    Members = new();
                }

                Debug.WriteLine("OnGet method completed.");
            }
        }
    }

