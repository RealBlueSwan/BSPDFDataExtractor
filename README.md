# PDF Data Extraction Project Documentation

## Project Overview

This project aims to extract data from predefined fields within PDF documents. It is designed as a simple console application to demonstrate the functionality. The primary goal is to create a solution that is easy to extend, understand, and implement in other projects. The application does not require any input from the user and is developed using the latest version of .NET Core.

## Requirements

- Error Handling: The application must raise errors and exceptions if any predefined field is not found within the PDF. It should provide clear and informative error messages to help locate the issue.
- Test Cases: The solution should include test cases to verify the correctness of the data extraction functionality.
- Extendability: The code should be written in a way that is easy to extend and adapt to other projects.

## Research and Libraries

During the initial research phase, several libraries and solutions for extracting data from PDFs in .NET Core were evaluated. The findings are summarized below:

- **iTextPDF**: This library is only free for non-commercial use.
- **PDFBox**: A Java library, not directly usable in .NET Core without additional bridging.
- **PDFSharp**: A C# library under the MIT license, making it free for commercial use. This library was chosen for the project. Source: [PDFSharp Purchase](https://www.pdfsharp.net/Purchase.ashx)
- **Toxy**: A C# library that, for reading PDFs, relies on `itextsharp.dll` version 5.5.0, which is not free.
- **Docotic.Pdf**: A library that is not free for use.

Additional resources and suggestions were found in a Stack Overflow post: [Read text from PDF on .NET Core using any open-source non-licensed packages](https://stackoverflow.com/questions/60451365/read-text-from-pdf-on-net-core-using-any-open-source-non-licensed-packages).

## Chosen Solution: PDFSharp

After evaluating various options, PDFSharp was selected for this project due to its MIT license and compatibility with commercial use. The library provides the necessary functionality to extract text from PDF documents, which is crucial for identifying and retrieving data from predefined fields.

## Implementation Details

The solution focuses on extracting flight data from PDF documents. Each piece of flight data is collected in an object, facilitating easy manipulation and access. The application is structured to ensure that it can be easily extended to include additional fields or adapt to different types of data extraction requirements.

## Questions and Answers

1. **How do we identify the fields in the PDF that contain the flight data?**
    - We can identify the fields by their position on the page, or by their text content.

2. **What format is the flight data stored in within the PDF?**
    - The flight data is stored as text in the PDF.

3. **How do we handle cases where a field is not found in the PDF?**
    - We can raise an error or exception if a field is not found in the PDF, or we could return N/A or some other default value.
    - The error message should be descriptive and help locate the issue.

4. **How do we create test cases to validate the correctness of the code?**
    - We already have a PDF with known flight data, and we can compare the extracted data with the expected values.

5. **How do we demonstrate the usage of the solution in a simple console application?**
    - ...