using FlightPlan.Application.Reports;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Reports
{
    public class SummaryModel : PageModel
    {
        private readonly IReportRepository _repository;

        public SummaryModel(IReportRepository repository)
        {
            _repository = repository;
        }

        public SummaryReport SummaryReport { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {            
            SummaryReport = await _repository.GetSummaryReport();
            
            return Page();
        }
    }
}