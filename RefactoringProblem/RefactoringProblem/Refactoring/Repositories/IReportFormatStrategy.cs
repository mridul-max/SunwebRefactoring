using Refactoring.Models;

namespace Refactoring.Repositories
{
    public interface IReportFormatStrategy
    {
        string GenerateReport(List<AccommodationBase> accommodations);
    }
}
