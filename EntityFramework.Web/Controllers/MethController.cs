using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEntityFramework.Models;

namespace EntityFramework.Web.Controllers
{
    public class MethController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public MethController(MunicipalDumaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: FPersons/Details/5
        public async Task<IActionResult> ShowComissMeeting(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            
            var query = _context.LComissionPerson
                                .Include(l => l.FComissionNavigation)
                                    .ThenInclude(f => f.FMeetings)
                                .Include(l => l.FPersonNavigation)
                                    .ThenInclude(f => f.LMeetingWorks).Where(x => x.FComissionNavigation.FComissionId == id);                                

            if (query == null)
            {
                return NotFound();
            }

            return View(query);

        }
    }
}
