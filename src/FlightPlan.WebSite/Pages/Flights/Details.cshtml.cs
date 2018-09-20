using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlightPlan.Sql.Entities;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly FlightPlan.Sql.Entities.DatabaseContext _context;

        public DetailsModel(FlightPlan.Sql.Entities.DatabaseContext context)
        {
            _context = context;
        }

        public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flights
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Plane).FirstOrDefaultAsync(m => m.Id == id);

            if (Flight == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
