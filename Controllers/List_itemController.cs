#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obermind.Data;
using Obermind.Models;

namespace Obermind.Controllers
{
    public class List_itemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public List_itemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: List_item
        public async Task<IActionResult> Index()
        {
            return View(await _context.List_item.ToListAsync());
        }

        // GET: List_item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list_item = await _context.List_item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (list_item == null)
            {
                return NotFound();
            }

            return View(list_item);
        }

        // GET: List_item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: List_item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,quantity")] List_item list_item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(list_item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(list_item);
        }

        // GET: List_item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list_item = await _context.List_item.FindAsync(id);
            if (list_item == null)
            {
                return NotFound();
            }
            return View(list_item);
        }

        // POST: List_item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantity")] List_item list_item)
        {
            if (id != list_item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(list_item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!List_itemExists(list_item.Id))
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
            return View(list_item);
        }

        // GET: List_item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list_item = await _context.List_item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (list_item == null)
            {
                return NotFound();
            }

            return View(list_item);
        }

        // POST: List_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var list_item = await _context.List_item.FindAsync(id);
            _context.List_item.Remove(list_item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool List_itemExists(int id)
        {
            return _context.List_item.Any(e => e.Id == id);
        }
    }
}
