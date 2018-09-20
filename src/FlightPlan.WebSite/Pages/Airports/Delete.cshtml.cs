using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Airports
{
    public class DeleteModel : PageModel
    {
        private readonly IAirportRepository _repository;

        public DeleteModel(IAirportRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Airport Airport { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport = await _repository.Get(id);

            if (Airport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
