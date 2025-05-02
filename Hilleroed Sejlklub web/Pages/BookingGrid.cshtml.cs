using Hilleroed_Sejlklub_Library;
using Hilleroed_Sejlklub_Library.Models;
using Hilleroed_Sejlklub_Library.Repos;
using Hilleroed_Sejlklub_Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;
using System.Diagnostics;
using System.Text.Json;
using System.Numerics;

namespace Hilleroed_Sejlklub_web.Pages
    {
        public class BookingGridModel : PageModel
        {
            public List<Booking> Bookings { get; set; } = new();
            private readonly string bookingFilePathJson;

            public BookingGridModel(IWebHostEnvironment environment)
            {
                bookingFilePathJson = Path.Combine(environment.ContentRootPath, "BookingData.json");
                Debug.WriteLine($"Booking file path: {bookingFilePathJson}"); // Log the file path for debugging
            }
            public void OnGet()
            {
                Debug.WriteLine("OnGet method started.");

                // Check if the file exists
                Debug.WriteLine($"Checking if file exists: {bookingFilePathJson}");
                if (System.IO.File.Exists(bookingFilePathJson))
                {
                    Debug.WriteLine("File found. Reading content...");
                    var json = System.IO.File.ReadAllText(bookingFilePathJson);

                    // Log the content of the file (optional, avoid for large files)
                    Debug.WriteLine($"File content: {json}");

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            // Attempt to deserialize the JSON
                            Debug.WriteLine("Deserializing JSON...");
                            Bookings = JsonSerializer.Deserialize<List<Booking>>(json) ?? new();
                            Debug.WriteLine($"Deserialization successful. Loaded {Bookings.Count} boats.");
                        }
                        catch (Exception ex)
                        {
                            // Log the exception
                            Debug.WriteLine($"Error deserializing JSON: {ex.Message}");
                            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                            Bookings = new();
                        }
                    }
                    else
                    {
                        Debug.WriteLine("File content is empty or whitespace.");
                        Bookings = new();
                    }
                }
                else
                {
                    Debug.WriteLine("File not found.");
                    Bookings = new();
                }

                Debug.WriteLine("OnGet method completed.");
            }

        }
    }

