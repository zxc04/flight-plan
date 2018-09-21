using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Planes
{
    public class DetailsModel : PageModel
    {
        private readonly IPlaneRepository _repository;

        public DetailsModel(IPlaneRepository repository)
        {
            _repository = repository;
        }

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
    }
}
