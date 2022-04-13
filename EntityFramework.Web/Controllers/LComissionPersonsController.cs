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
    public class LComissionPersonsController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public LComissionPersonsController(MunicipalDumaContext context)
        {
            _context = context;
        }

        // GET: LComissionPersons
        public async Task<IActionResult> Index()
        {
            var municipalDumaContext = _context.LComissionperson.Include(l => l.FComissionNavigation).Include(l => l.FPersonNavigation);
            return View(await municipalDumaContext.ToListAsync());
        }

        // GET: LComissionPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lComissionPerson = await _context.LComissionperson
                .Include(l => l.FComissionNavigation)
                .Include(l => l.FPersonNavigation)
                .FirstOrDefaultAsync(m => m.LComissionPersonId == id);
            if (lComissionPerson == null)
            {
                return NotFound();
            }

            return View(lComissionPerson);
        }

        // GET: LComissionPersons/Create
        public IActionResult Create()
        {
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name");
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId");
            return View();
        }

        // POST: LComissionPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LComissionPersonId,FComission,FPerson,Stat,StatMain,DateBegin,DateEnd")] LComissionPerson lComissionPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lComissionPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", lComissionPerson.FComission);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lComissionPerson.FPerson);
            return View(lComissionPerson);
        }

        // GET: LComissionPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lComissionPerson = await _context.LComissionperson.FindAsync(id);
            if (lComissionPerson == null)
            {
                return NotFound();
            }
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", lComissionPerson.FComission);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lComissionPerson.FPerson);
            return View(lComissionPerson);
        }

        // POST: LComissionPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LComissionPersonId,FComission,FPerson,Stat,StatMain,DateBegin,DateEnd")] LComissionPerson lComissionPerson)
        {
            if (id != lComissionPerson.LComissionPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lComissionPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LComissionPersonExists(lComissionPerson.LComissionPersonId))
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
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", lComissionPerson.FComission);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lComissionPerson.FPerson);
            return View(lComissionPerson);
        }

        // GET: LComissionPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lComissionPerson = await _context.LComissionperson
                .Include(l => l.FComissionNavigation)
                .Include(l => l.FPersonNavigation)
                .FirstOrDefaultAsync(m => m.LComissionPersonId == id);
            if (lComissionPerson == null)
            {
                return NotFound();
            }

            return View(lComissionPerson);
        }

        // POST: LComissionPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lComissionPerson = await _context.LComissionperson.FindAsync(id);
            _context.LComissionperson.Remove(lComissionPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LComissionPersonExists(int id)
        {
            return _context.LComissionperson.Any(e => e.LComissionPersonId == id);
        }
    }
}
