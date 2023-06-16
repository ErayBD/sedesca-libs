using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Context;
using ServiceLayer.Models;

namespace ServiceLayer.Controllers
{
	[Authorize]
	public class StudentBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentBooks
        public async Task<IActionResult> Index()
        {
              return _context.StudentBooks != null ? 
                          View(await _context.StudentBooks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentBooks'  is null.");
        }

        // GET: StudentBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentBooks == null)
            {
                return NotFound();
            }

            var studentBook = await _context.StudentBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentBook == null)
            {
                return NotFound();
            }

            return View(studentBook);
        }

        // GET: StudentBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,studentId,bookId")] StudentBook studentBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentBook);
        }

        // GET: StudentBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentBooks == null)
            {
                return NotFound();
            }

            var studentBook = await _context.StudentBooks.FindAsync(id);
            if (studentBook == null)
            {
                return NotFound();
            }
            return View(studentBook);
        }

        // POST: StudentBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,studentId,bookId")] StudentBook studentBook)
        {
            if (id != studentBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentBookExists(studentBook.Id))
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
            return View(studentBook);
        }

        // GET: StudentBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentBooks == null)
            {
                return NotFound();
            }

            var studentBook = await _context.StudentBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentBook == null)
            {
                return NotFound();
            }

            return View(studentBook);
        }

        // POST: StudentBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentBooks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentBooks'  is null.");
            }
            var studentBook = await _context.StudentBooks.FindAsync(id);
            if (studentBook != null)
            {
                _context.StudentBooks.Remove(studentBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentBookExists(int id)
        {
          return (_context.StudentBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
