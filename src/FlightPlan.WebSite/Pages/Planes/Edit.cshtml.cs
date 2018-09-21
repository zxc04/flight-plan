using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Planes
{
    public class EditModel : PageModel
    {
        private readonly IPlaneRepository _repository;

        public EditModel(IPlaneRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Plane Plane { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plane = await _repository.Get(id);

            if (Plane == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _repository.CreateOrUpdate(Plane);

            if(result == null)
                return NotFound();

            return RedirectToPage("./Details", new { id = result });
        }
    }
}
