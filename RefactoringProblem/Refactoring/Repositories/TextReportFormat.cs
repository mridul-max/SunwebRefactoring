using Refactoring.Models;
using System.Text;

namespace Refactoring.Repositories
{
    public class TextReportFormat : IReportFormatStrategy
    {
        public string GenerateReport(List<AccommodationBase> accommodations)
        {
            if (accommodations == null || accommodations.Count == 0)
                return $"<p>Empty list of accommodations!</p>";

            var report = new StringBuilder();
            report.AppendLine("<html><body>");
            report.AppendLine($"<h1>Accommodation Report</h1>");
            report.AppendLine("<tr><th>Count</th><th>Type</th><th>Revenue</th><th>Profit</th></tr>");

            var grouped = accommodations.GroupBy(a => a.Name);
            double totalRevenue = 0, totalProfit = 0;
            int totalCount = 0;

            foreach (var group in grouped)
            {
                int count = group.Count();
                double revenue = group.Sum(a => a.CalculateRevenue());
                double profit = group.Sum(a => a.CalculateProfit());

                totalCount += count;
                totalRevenue += revenue;
                totalProfit += profit;

                report.AppendLine($"<tr><td>{count}</td><td>{group.Key}</td>" +
                                  $"<td>{revenue:0.00}</td><td>{profit:0.00}</td></tr>");
            }
            report.AppendLine("</table>");
            report.AppendLine($"<p>Totals :</p>");
            report.AppendLine($"<p>: {totalCount}</p>");
            report.AppendLine($"<p>Revenue : {totalRevenue:0.00}</p>");
            report.AppendLine($"<p>Profit: {totalProfit:0.00}</p>");
            report.AppendLine("</body></html>");

            return report.ToString();
        }
    }
}
