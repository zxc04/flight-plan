using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Airports
{
    public class CreateModel : PageModel
    {
        private readonly IAirportRepository _repository;

        public CreateModel(IAirportRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Airport Airport { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateOrUpdate(Airport);

            return RedirectToPage("./Index");
        }
    }
}