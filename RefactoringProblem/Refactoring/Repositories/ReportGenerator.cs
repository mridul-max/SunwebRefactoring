using Refactoring.Models;

namespace Refactoring.Repositories
{
    public class ReportGenerator
    {
        private readonly IReportFormatStrategy _reportFormat;

        public ReportGenerator(IReportFormatStrategy reportFormat)
        {
            _reportFormat = reportFormat;
        }

        public string GenerateReport(List<AccommodationBase> accommodations)
        {
            return _reportFormat.GenerateReport(accommodations);
        }
    }
}
