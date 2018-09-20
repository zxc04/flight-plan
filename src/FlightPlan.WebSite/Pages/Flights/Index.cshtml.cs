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
    public class IndexModel : PageModel
    {
        private readonly FlightPlan.Sql.Entities.DatabaseContext _context;

        public IndexModel(FlightPlan.Sql.Entities.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Flight> Flight { get;set; }

        public async Task OnGetAsync()
        {
            Flight = await _context.Flights
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Plane).ToListAsync();
        }
    }
}
