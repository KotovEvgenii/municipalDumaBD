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
    public class FPersonsController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public FPersonsController(MunicipalDumaContext context)
        {
            _context = context;
        }

        // GET: FPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.FPerson.ToListAsync());
        }

        // GET: FPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fPerson = await _context.FPerson
                .FirstOrDefaultAsync(m => m.FPersonId == id);
            if (fPerson == null)
            {
                return NotFound();
            }

            return View(fPerson);
        }

        // GET: FPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FPersonId,Name,Surname,Address,PhoneNumber")] FPerson fPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fPerson);
        }

        // GET: FPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fPerson = await _context.FPerson.FindAsync(id);
            if (fPerson == null)
            {
                return NotFound();
            }
            return View(fPerson);
        }

        // POST: FPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FPersonId,Name,Surname,Address,PhoneNumber")] FPerson fPerson)
        {
            if (id != fPerson.FPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FPersonExists(fPerson.FPersonId))
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
            return View(fPerson);
        }

        // GET: FPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fPerson = await _context.FPerson
                .FirstOrDefaultAsync(m => m.FPersonId == id);
            if (fPerson == null)
            {
                return NotFound();
            }

            return View(fPerson);
        }

        // POST: FPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fPerson = await _context.FPerson.FindAsync(id);
            _context.FPerson.Remove(fPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FPersonExists(int id)
        {
            return _context.FPerson.Any(e => e.FPersonId == id);
        }
    }
}
