using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telephones.Data;
using Telephones.Models;


namespace Telephones.Controllers
{
    public class InformationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Information
        public async Task<IActionResult> Index()
        {
              return View(await _context.Information.ToListAsync());
        }

        // GET: Information/SearchPhone
        public async Task<IActionResult> SearchPhone()
        {
            return View();
        }

        // POST: Information/ResultSearchPhone
        public async Task<IActionResult> ShowResultPhone(string SearchPhoneNumber)
        {
            return View("ShowResultPhone", await _context.Information.Where(j => j.PhoneNumber.Contains(SearchPhoneNumber)).ToListAsync());
        }

        // GET: Information/SearchName
        public async Task<IActionResult> SearchName()
        {
            return View();
        }

        // POST: Information/ShowResultName
        public async Task<IActionResult> ShowResultName(string SearchName)
        {
            return View("ShowResultName", await _context.Information.Where(j => j.Name.Contains(SearchName)).ToListAsync());
        }

        // GET: Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Information == null)
            {
                return NotFound();
            }

            var information = await _context.Information
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // GET: Information/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,Name,Email")] Information information)
        {
            if (ModelState.IsValid)
            {
                _context.Add(information);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(information);
        }

        // GET: Information/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Information == null)
            {
                return NotFound();
            }

            var information = await _context.Information.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }
            return View(information);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNumber,Name,Email")] Information information)
        {
            if (id != information.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(information);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformationExists(information.Id))
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
            return View(information);
        }

        // GET: Information/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Information == null)
            {
                return NotFound();
            }

            var information = await _context.Information
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // POST: Information/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Information == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Information'  is null.");
            }
            var information = await _context.Information.FindAsync(id);
            if (information != null)
            {
                _context.Information.Remove(information);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformationExists(int id)
        {
          return _context.Information.Any(e => e.Id == id);
        }
    }
}
