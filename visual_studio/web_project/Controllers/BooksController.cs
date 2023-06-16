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
	public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index() {
            var books = await _context.Books
                              .Include(b => b.Author)
                              .Include(b => b.Genre)
                              .ToListAsync();
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(books);
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)              
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,authorId,genreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,authorId,genreId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Genre = new SelectList(_context.Genre, "Id", "genreName");
            ViewBag.Author = new SelectList(_context.Author, "Id", "authorName");
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Borrow(int? id) {
            if (id == null) {
                return NotFound();
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null) {
                return NotFound();
            }

            var myBook = new MyBooks {
                title = book.title,
                authorId = book.authorId,
                genreId = book.genreId,
                BookId = book.Id
            };

            _context.MyBooks.Add(myBook);
            
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

    }

}
