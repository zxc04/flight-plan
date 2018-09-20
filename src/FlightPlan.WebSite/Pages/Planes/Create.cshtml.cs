using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Planes
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneRepository _repository;

        public CreateModel(IPlaneRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plane Plane { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateOrUpdate(Plane);

            return RedirectToPage("./Index");
        }
    }
}