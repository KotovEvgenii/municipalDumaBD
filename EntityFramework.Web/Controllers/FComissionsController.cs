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
    public class FComissionsController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public FComissionsController(MunicipalDumaContext context)
        {
            _context = context;
        }

        // GET: FComissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FComissions.ToListAsync());
        }

        // GET: FComissions/Details/5
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

        // GET: FComissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FComissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FComissionId,Name")] FComission fComission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fComission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fComission);
        }

        // GET: FComissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fComission = await _context.FComissions.FindAsync(id);
            if (fComission == null)
            {
                return NotFound();
            }
            return View(fComission);
        }

        // POST: FComissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FComissionId,Name")] FComission fComission)
        {
            if (id != fComission.FComissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fComission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FComissionExists(fComission.FComissionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fComission);
        }

        // GET: FComissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: FComissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fComission = await _context.FComissions.FindAsync(id);
            _context.FComissions.Remove(fComission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FComissionExists(int id)
        {
            return _context.FComissions.Any(e => e.FComissionId == id);
        }
    }
}
