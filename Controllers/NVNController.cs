using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NVN123.Models;

namespace NVN123.Controllers
{
    public class NVNController : Controller
    {
        private readonly ApplicationDBContext _context;

        public NVNController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: NVN
        public async Task<IActionResult> Index()
        {
            return View(await _context.NVN.ToListAsync());
        }

        // GET: NVN/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nVN = await _context.NVN
                .FirstOrDefaultAsync(m => m.NVNID == id);
            if (nVN == null)
            {
                return NotFound();
            }

            return View(nVN);
        }

        // GET: NVN/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NVNID,NVNName,Genre")] NVN nVN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVN);
        }

        // GET: NVN/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nVN = await _context.NVN.FindAsync(id);
            if (nVN == null)
            {
                return NotFound();
            }
            return View(nVN);
        }

        // POST: NVN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NVNID,NVNName,Genre")] NVN nVN)
        {
            if (id != nVN.NVNID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVNExists(nVN.NVNID))
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
            return View(nVN);
        }

        // GET: NVN/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nVN = await _context.NVN
                .FirstOrDefaultAsync(m => m.NVNID == id);
            if (nVN == null)
            {
                return NotFound();
            }

            return View(nVN);
        }

        // POST: NVN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nVN = await _context.NVN.FindAsync(id);
            _context.NVN.Remove(nVN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVNExists(string id)
        {
            return _context.NVN.Any(e => e.NVNID == id);
        }
    }
}
