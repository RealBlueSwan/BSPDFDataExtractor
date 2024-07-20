using System;                       // Console
using System.IO;                    // Directory
using System.Collections.Generic;   // List
using System.Text.RegularExpressions; // Regex
using UglyToad.PdfPig;              // PdfDocument

class Program
{
    static void Main()
    {   
        // Check if no PDF files are found in the directory before attempting to access them
        if (Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.pdf").Length == 0)
        {
            Console.WriteLine("No PDF files found in the directory.");
            return;
        }
        
        // Get the first PDF file found in the directory could be changed to any location or file
        string pdfFileName = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.pdf")[0];

        // Print the name of the PDF file being processed
        Console.WriteLine($"Processing file: {pdfFileName}");

        // Lists to store flight numbers, relevant pages, and flight data
        List<string> flightNumbers = new List<string>();
        List<int> relevantPages = new List<int>();
        List<FlightData> flightData = new List<FlightData>();

        // Open the PDF file
        using (PdfDocument document = PdfDocument.Open(pdfFileName))
        {   
            // Check if the PDF file is encrypted, contains no pages, or contains only one page
            if (document.IsEncrypted)
            {
                Console.WriteLine("The PDF document is encrypted and cannot be processed.");
                return;
            }

            if (document.NumberOfPages == 0)
            {
                Console.WriteLine("The PDF document does not contain any pages.");
                return;
            }

            var page = document.GetPage(1);
            var text = page.Text;
            string pattern = @"LX\d{4}";
            MatchCollection matches = Regex.Matches(text, pattern);

            // Check if any flight numbers are found in the PDF file
            if (matches.Count == 0)
            {
                Console.WriteLine("No flight numbers found in the PDF file.");
                return;
            }

            foreach (Match match in matches)
            {
                flightNumbers.Add(match.Value);
            }

            // Print the number of flight numbers found in the PDF file
            Console.WriteLine($"Found {flightNumbers.Count} flight numbers in the PDF file.");

            // Check if the PDF file contains only one page
            if (document.NumberOfPages == 1)
            {
                Console.WriteLine("The PDF document contains only one page.");
                return;
            }

            // We start from the second page since the first page is already processed
            // We check for specific keywords to identify relevant pages in the PDF file
            for (int i = 2; i <= document.NumberOfPages; i++)
            {   
                page = document.GetPage(i);
                text = page.Text;
                // Maybe a little more complex logic is needed here to identify relevant pages but this works for now... probably only now :)
                if (text.Contains("Commander") || text.Contains("Helvetic Airways - E-Jet Operational Flight Plan"))
                {
                    relevantPages.Add(i);
                }
            }

            // Check if any relevant pages are found in the PDF file
            if (relevantPages.Count == 0)
            {
                Console.WriteLine("No relevant pages found in the PDF file.");
                return;
            }

            // Print the number of relevant pages found in the PDF file
            Console.WriteLine($"Found {relevantPages.Count} relevant pages in the PDF file.");

            // Extract flight data from relevant pages based on flight numbers
            foreach (string flightNumber in flightNumbers)
            {
                foreach (int pageNumber in relevantPages)
                {
                    page = document.GetPage(pageNumber);
                    text = page.Text;
                    if (text.Contains(flightNumber))
                    {   
                        // Use Regex to extract the flight date from the relevant page its in the format "Date: 19MAR24"
                        string flightDate = Regex.Match(text, @"Date: \d{2}[A-Z]{3}\d{2}").Value;
                        // only want the date part
                        flightDate = flightDate.Replace("Date: ", "");
                        // check if the flight date is found
                        if (string.IsNullOrEmpty(flightDate)) // Probelem here is that as soon as it reaches the second 
                        //page with the flight number it will not find the date and raise this error, maybe just leave 
                        //this erorr message out to not confuse the user
                        {
                            Console.WriteLine($"Flight date not found for flight number: {flightNumber}");
                            continue;
                        }

                        // Add the flight data to the list, can extend this to store more data if needed
                        flightData.Add(new FlightData(flightNumber, flightDate));
                        break;
                    }
                }
            }
        }

        // Assuming you want to do something with flightData here, like printing it out
        foreach (var data in flightData)
        {
            Console.WriteLine($"Flight Number: {data.FlightNumber}, Flight Date: {data.FlightDate}");
        }
        // Create a CSV file with the flight data
        using (StreamWriter file = new StreamWriter("flight_data.csv"))
        {
            file.WriteLine("Flight Number,Flight Date");
            foreach (var data in flightData)
            {
                file.WriteLine($"{data.FlightNumber},{data.FlightDate}");
            }
        }
        // Print the name of the CSV file created
        Console.WriteLine("CSV file created: flight_data.csv");

        // Pause the console so the user can read the output
        Console.ReadLine();

        // Exit the program
        return;
    }
}

internal class FlightData
{
    public string FlightNumber { get; set; }
    public string FlightDate { get; set; }

    public FlightData(string flightNumber, string flightDate)
    {
        FlightNumber = flightNumber;
        FlightDate = flightDate;
    }
}