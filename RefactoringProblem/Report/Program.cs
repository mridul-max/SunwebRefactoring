using Refactoring.Models;
using Refactoring.Repositories;

namespace Report;
class Program
{
    static void Main()
    {
        // Sample accommodations
        var accommodations = new List<AccommodationBase>
        {
            new Hotel("Luxury Hotel", 200, 20, 50),
            new Camping("Sunny Camping", 50, 10, 5),
            new Apartment("City Apartment", 100, 15, 3)
        };

        IReportFormatStrategy textReportStrategy = new TextReportFormat();

        // Generate the report
        var reportGenerator = new ReportGenerator(textReportStrategy);
        string report = reportGenerator.GenerateReport(accommodations);

        // Output the report
        Console.WriteLine(report);
    }
}