using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Context;
using ServiceLayer.Models;

namespace ServiceLayer.Controllers
{
    public class ReturnBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReturnBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReturnBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReturnBook.Include(r => r.Author).Include(r => r.Book).Include(r => r.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReturnBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReturnBook == null)
            {
                return NotFound();
            }

            var returnBook = await _context.ReturnBook
                .Include(r => r.Author)
                .Include(r => r.Book)
                .Include(r => r.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (returnBook == null)
            {
                return NotFound();
            }

            return View(returnBook);
        }

        // GET: ReturnBooks/Create
        public IActionResult Create()
        {
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id");
            return View();
        }

        // POST: ReturnBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,authorId,genreId,BookId")] ReturnBook returnBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", returnBook.authorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", returnBook.BookId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", returnBook.genreId);
            return View(returnBook);
        }

        // GET: ReturnBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReturnBook == null)
            {
                return NotFound();
            }

            var returnBook = await _context.ReturnBook.FindAsync(id);
            if (returnBook == null)
            {
                return NotFound();
            }
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", returnBook.authorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", returnBook.BookId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", returnBook.genreId);
            return View(returnBook);
        }

        // POST: ReturnBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,authorId,genreId,BookId")] ReturnBook returnBook)
        {
            if (id != returnBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnBookExists(returnBook.Id))
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
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", returnBook.authorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", returnBook.BookId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", returnBook.genreId);
            return View(returnBook);
        }

        // GET: ReturnBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReturnBook == null)
            {
                return NotFound();
            }

            var returnBook = await _context.ReturnBook
                .Include(r => r.Author)
                .Include(r => r.Book)
                .Include(r => r.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (returnBook == null)
            {
                return NotFound();
            }

            return View(returnBook);
        }

        // POST: ReturnBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReturnBook == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ReturnBook'  is null.");
            }
            var returnBook = await _context.ReturnBook.FindAsync(id);
            if (returnBook != null)
            {
                _context.ReturnBook.Remove(returnBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnBookExists(int id)
        {
          return (_context.ReturnBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
