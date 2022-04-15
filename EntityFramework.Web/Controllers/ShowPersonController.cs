using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestEntityFramework.Models;

namespace EntityFramework.Web.Controllers
{
    public class ShowPersonController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public ShowPersonController(MunicipalDumaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fComission = await _context.FComissions
                .FirstOrDefaultAsync(m => m.FComissionId == id);
            if (fComission == null)
            {
                return NotFound();
            }

            return View(fComission);
        }
    }
}
