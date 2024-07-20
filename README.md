# PDF Flight Data Extractor

## Overview
This C# console application extracts flight data from PDF files. It identifies flight numbers and relevant pages within a PDF document, extracts flight dates based on those numbers, and generates a CSV file with the collected data. The application is designed to provide feedback during the process and logs errors for further inspection without terminating the program.

## Features
- Automatically scans a directory for PDF files, selecting the first one found for processing.
- Utilizes a predefined pattern to extract flight numbers from the document.
- Identifies pages containing specific keywords such as "Commander" and "Helvetic Airways - E-Jet Operational Flight Plan" to find relevant data.
- Extracts and matches flight dates for each identified flight number.
- Outputs the extracted data into a CSV file named `flight_data.csv`.

## Requirements
- .NET Core 3.1 or later.
- UglyToad.PdfPig library for PDF text extraction.

## Usage
1. Place the PDF file(s) you intend to process in the same directory as the executable.
2. Execute the application. Progress and results will be displayed in the console.
3. Upon completion, the `flight_data.csv` file containing the extracted flight data will be available in the same directory.

## Error Handling
The application is designed to handle errors gracefully:
- If a page does not contain the desired information, the program logs the error and continues, ensuring partial data is still processed and recorded.

## Dependencies and Licenses
- **UglyToad.PdfPig**: A library used for reading and extracting text from PDF files, licensed under the Apache License 2.0. For more details, visit [their GitHub repository](https://github.com/UglyToad/PdfPig).

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.