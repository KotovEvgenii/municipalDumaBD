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
    public class FMeetingsController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public FMeetingsController(MunicipalDumaContext context)
        {
            _context = context;
        }

        // GET: FMeetings
        public async Task<IActionResult> Index()
        {
            var municipalDumaContext = _context.FMeetings.Include(f => f.FComissionNavigation);
            return View(await municipalDumaContext.ToListAsync());
        }

        // GET: FMeetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fMeeting = await _context.FMeetings
                .Include(f => f.FComissionNavigation)
                .FirstOrDefaultAsync(m => m.FMeetingId == id);
            if (fMeeting == null)
            {
                return NotFound();
            }

            return View(fMeeting);
        }

        // GET: FMeetings/Create
        public IActionResult Create()
        {
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name");
            return View();
        }

        // POST: FMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FMeetingId,FComission,DateTime,Place")] FMeeting fMeeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fMeeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", fMeeting.FComission);
            return View(fMeeting);
        }

        // GET: FMeetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fMeeting = await _context.FMeetings.FindAsync(id);
            if (fMeeting == null)
            {
                return NotFound();
            }
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", fMeeting.FComission);
            return View(fMeeting);
        }

        // POST: FMeetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FMeetingId,FComission,DateTime,Place")] FMeeting fMeeting)
        {
            if (id != fMeeting.FMeetingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fMeeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FMeetingExists(fMeeting.FMeetingId))
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
            ViewData["FComission"] = new SelectList(_context.FComissions, "FComissionId", "Name", fMeeting.FComission);
            return View(fMeeting);
        }

        // GET: FMeetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fMeeting = await _context.FMeetings
                .Include(f => f.FComissionNavigation)
                .FirstOrDefaultAsync(m => m.FMeetingId == id);
            if (fMeeting == null)
            {
                return NotFound();
            }

            return View(fMeeting);
        }

        // POST: FMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fMeeting = await _context.FMeetings.FindAsync(id);
            _context.FMeetings.Remove(fMeeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FMeetingExists(int id)
        {
            return _context.FMeetings.Any(e => e.FMeetingId == id);
        }
    }
}
