using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cust_crrud.Data;
using cust_crrud.Models;

namespace cust_crrud.Controllers
{
    public class CustsController : Controller
    {
        private readonly cust_crrudContext _context;

        public CustsController(cust_crrudContext context)
        {
            _context = context;
        }

        // GET: Custs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cust.ToListAsync());
        }

        // GET: Custs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // GET: Custs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Custs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Email")] Cust cust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cust);
        }

        // GET: Custs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        // POST: Custs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Email")] Cust cust)
        {
            if (id != cust.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustExists(cust.Id))
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
            return View(cust);
        }

        // GET: Custs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // POST: Custs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cust = await _context.Cust.FindAsync(id);
            if (cust != null)
            {
                _context.Cust.Remove(cust);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustExists(int id)
        {
            return _context.Cust.Any(e => e.Id == id);
        }
    }
}
