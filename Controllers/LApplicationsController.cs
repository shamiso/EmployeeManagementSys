using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSys.Data;
using EmployeeManagementSys.Models;

namespace EmployeeManagementSys.Controllers
{
    public class LApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LApplications.Include(l => l.Duration).Include(l => l.Employee).Include(l => l.LeaveType).Include(l => l.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lApplication = await _context.LApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lApplication == null)
            {
                return NotFound();
            }

            return View(lApplication);
        }

        // GET: LApplications/Create
        public IActionResult Create()
        {
            ViewData["DurationId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id");
            return View();
        }

        // POST: LApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,NumOfDays,StartDate,EndDate,DurationId,LeaveTypeId,Attachment,Description,StatusId,ApprovedById,ApprovedOn,CreatedById,CreatedOn,ModifiedById,ModifiedOn")] LApplication lApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", lApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", lApplication.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.StatusId);
            return View(lApplication);
        }

        // GET: LApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lApplication = await _context.LApplications.FindAsync(id);
            if (lApplication == null)
            {
                return NotFound();
            }
            ViewData["DurationId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", lApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", lApplication.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.StatusId);
            return View(lApplication);
        }

        // POST: LApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,NumOfDays,StartDate,EndDate,DurationId,LeaveTypeId,Attachment,Description,StatusId,ApprovedById,ApprovedOn,CreatedById,CreatedOn,ModifiedById,ModifiedOn")] LApplication lApplication)
        {
            if (id != lApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LApplicationExists(lApplication.Id))
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
            ViewData["DurationId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", lApplication.EmployeeId);
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", lApplication.LeaveTypeId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodeDetails, "Id", "Id", lApplication.StatusId);
            return View(lApplication);
        }

        // GET: LApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lApplication = await _context.LApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lApplication == null)
            {
                return NotFound();
            }

            return View(lApplication);
        }

        // POST: LApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lApplication = await _context.LApplications.FindAsync(id);
            if (lApplication != null)
            {
                _context.LApplications.Remove(lApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LApplicationExists(int id)
        {
            return _context.LApplications.Any(e => e.Id == id);
        }
    }
}
