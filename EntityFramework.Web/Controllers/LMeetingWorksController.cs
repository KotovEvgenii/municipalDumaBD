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
    public class LMeetingWorksController : Controller
    {
        private readonly MunicipalDumaContext _context;

        public LMeetingWorksController(MunicipalDumaContext context)
        {
            _context = context;
        }

        // GET: LMeetingWorks
        public async Task<IActionResult> Index()
        {
            var municipalDumaContext = _context.LMeetingWorks.Include(l => l.FMeetingNavigation).Include(l => l.FPersonNavigation);
            return View(await municipalDumaContext.ToListAsync());
        }

        // GET: LMeetingWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lMeetingWork = await _context.LMeetingWorks
                .Include(l => l.FMeetingNavigation)
                .Include(l => l.FPersonNavigation)
                .FirstOrDefaultAsync(m => m.LMeetingWorkId == id);
            if (lMeetingWork == null)
            {
                return NotFound();
            }

            return View(lMeetingWork);
        }

        // GET: LMeetingWorks/Create
        public IActionResult Create()
        {
            ViewData["FMeeting"] = new SelectList(_context.FMeetings, "FMeetingId", "FMeetingId");
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId");
            return View();
        }

        // POST: LMeetingWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LMeetingWorkId,FMeeting,FPerson,IsAbsent")] LMeetingWork lMeetingWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lMeetingWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FMeeting"] = new SelectList(_context.FMeetings, "FMeetingId", "FMeetingId", lMeetingWork.FMeeting);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lMeetingWork.FPerson);
            return View(lMeetingWork);
        }

        // GET: LMeetingWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lMeetingWork = await _context.LMeetingWorks.FindAsync(id);
            if (lMeetingWork == null)
            {
                return NotFound();
            }
            ViewData["FMeeting"] = new SelectList(_context.FMeetings, "FMeetingId", "FMeetingId", lMeetingWork.FMeeting);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lMeetingWork.FPerson);
            return View(lMeetingWork);
        }

        // POST: LMeetingWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LMeetingWorkId,FMeeting,FPerson,IsAbsent")] LMeetingWork lMeetingWork)
        {
            if (id != lMeetingWork.LMeetingWorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lMeetingWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LMeetingWorkExists(lMeetingWork.LMeetingWorkId))
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
            ViewData["FMeeting"] = new SelectList(_context.FMeetings, "FMeetingId", "FMeetingId", lMeetingWork.FMeeting);
            ViewData["FPerson"] = new SelectList(_context.FPerson, "FPersonId", "FPersonId", lMeetingWork.FPerson);
            return View(lMeetingWork);
        }

        // GET: LMeetingWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lMeetingWork = await _context.LMeetingWorks
                .Include(l => l.FMeetingNavigation)
                .Include(l => l.FPersonNavigation)
                .FirstOrDefaultAsync(m => m.LMeetingWorkId == id);
            if (lMeetingWork == null)
            {
                return NotFound();
            }

            return View(lMeetingWork);
        }

        // POST: LMeetingWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lMeetingWork = await _context.LMeetingWorks.FindAsync(id);
            _context.LMeetingWorks.Remove(lMeetingWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LMeetingWorkExists(int id)
        {
            return _context.LMeetingWorks.Any(e => e.LMeetingWorkId == id);
        }
    }
}
