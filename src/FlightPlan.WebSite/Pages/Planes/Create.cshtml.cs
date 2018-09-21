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

            var result = await _repository.CreateOrUpdate(Plane);

            if (result == null)
                return RedirectToPage("./Index");

            return RedirectToPage("./Details", new { id = result });
        }
    }
}