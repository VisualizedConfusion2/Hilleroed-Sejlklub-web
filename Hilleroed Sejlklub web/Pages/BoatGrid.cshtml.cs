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
    public class BoatGridModel : PageModel
    {
        public List<Boat> Boats { get; set; } = new();

        private readonly string boatFilePathJson;

        public BoatGridModel(IWebHostEnvironment environment)
        {
            boatFilePathJson = Path.Combine(environment.ContentRootPath, "BoatData.json");
            Debug.WriteLine($"Boat file path: {boatFilePathJson}"); // Log the file path for debugging
        }
        public void OnGet()
        {
            Debug.WriteLine("OnGet method started.");

            // Check if the file exists
            Debug.WriteLine($"Checking if file exists: {boatFilePathJson}");
            if (System.IO.File.Exists(boatFilePathJson))
            {
                Debug.WriteLine("File found. Reading content...");
                var json = System.IO.File.ReadAllText(boatFilePathJson);

                // Log the content of the file (optional, avoid for large files)
                Debug.WriteLine($"File content: {json}");

                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        // Attempt to deserialize the JSON
                        Debug.WriteLine("Deserializing JSON...");
                        Boats = JsonSerializer.Deserialize<List<Boat>>(json) ?? new();
                        Debug.WriteLine($"Deserialization successful. Loaded {Boats.Count} boats.");
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        Debug.WriteLine($"Error deserializing JSON: {ex.Message}");
                        Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                        Boats = new();
                    }
                }
                else
                {
                    Debug.WriteLine("File content is empty or whitespace.");
                    Boats = new();
                }
            }
            else
            {
                Debug.WriteLine("File not found.");
                Boats = new();
            }

            Debug.WriteLine("OnGet method completed.");
        }
    }
}
