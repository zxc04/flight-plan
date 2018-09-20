using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Planes
{
    public class IndexModel : PageModel
    {
        private readonly IPlaneRepository _repository;

        public IndexModel(IPlaneRepository repository)
        {
            _repository = repository;
        }

        public IList<Plane> Planes { get;set; }

        public async Task OnGetAsync()
        {
            Planes = await _repository.GetAll();
        }
    }
}
