using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matsu.CoreSample.Web.Data;
using Matsu.CoreSample.Web.Models;

namespace Matsu.CoreSample.Web.Controllers
{
    public class KeyValuesController : Controller
    {
        private readonly MyDatabaseContext _context;

        public KeyValuesController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: KeyValues
        public async Task<IActionResult> Index()
        {
              return _context.KeyValue != null ? 
                          View(await _context.KeyValue.ToListAsync()) :
                          Problem("Entity set 'MyDatabaseContext.KeyValue'  is null.");
        }

        // GET: KeyValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KeyValue == null)
            {
                return NotFound();
            }

            var keyValue = await _context.KeyValue
                .FirstOrDefaultAsync(m => m.id == id);
            if (keyValue == null)
            {
                return NotFound();
            }

            return View(keyValue);
        }

        // GET: KeyValues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KeyValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] KeyValue keyValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyValue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyValue);
        }

        // GET: KeyValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KeyValue == null)
            {
                return NotFound();
            }

            var keyValue = await _context.KeyValue.FindAsync(id);
            if (keyValue == null)
            {
                return NotFound();
            }
            return View(keyValue);
        }

        // POST: KeyValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] KeyValue keyValue)
        {
            if (id != keyValue.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyValue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyValueExists(keyValue.id))
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
            return View(keyValue);
        }

        // GET: KeyValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KeyValue == null)
            {
                return NotFound();
            }

            var keyValue = await _context.KeyValue
                .FirstOrDefaultAsync(m => m.id == id);
            if (keyValue == null)
            {
                return NotFound();
            }

            return View(keyValue);
        }

        // POST: KeyValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KeyValue == null)
            {
                return Problem("Entity set 'MyDatabaseContext.KeyValue'  is null.");
            }
            var keyValue = await _context.KeyValue.FindAsync(id);
            if (keyValue != null)
            {
                _context.KeyValue.Remove(keyValue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyValueExists(int id)
        {
          return (_context.KeyValue?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
