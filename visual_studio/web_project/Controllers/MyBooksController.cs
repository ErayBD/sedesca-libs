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
    public class MyBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MyBooks.Include(m => m.Author).Include(m => m.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyBooks == null)
            {
                return NotFound();
            }

            var myBooks = await _context.MyBooks
                .Include(m => m.Author)
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myBooks == null)
            {
                return NotFound();
            }

            return View(myBooks);
        }

        // GET: MyBooks/Create
        public IActionResult Create()
        {
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id");
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id");
            return View();
        }

        // POST: MyBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,authorId,genreId")] MyBooks myBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", myBooks.authorId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", myBooks.genreId);
            return View(myBooks);
        }

        // GET: MyBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyBooks == null)
            {
                return NotFound();
            }

            var myBooks = await _context.MyBooks.FindAsync(id);
            if (myBooks == null)
            {
                return NotFound();
            }
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", myBooks.authorId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", myBooks.genreId);
            return View(myBooks);
        }

        // POST: MyBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,authorId,genreId")] MyBooks myBooks)
        {
            if (id != myBooks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyBooksExists(myBooks.Id))
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
            ViewData["authorId"] = new SelectList(_context.Author, "Id", "Id", myBooks.authorId);
            ViewData["genreId"] = new SelectList(_context.Genre, "Id", "Id", myBooks.genreId);
            return View(myBooks);
        }

        // GET: MyBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyBooks == null)
            {
                return NotFound();
            }

            var myBooks = await _context.MyBooks
                .Include(m => m.Author)
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myBooks == null)
            {
                return NotFound();
            }

            return View(myBooks);
        }

        // POST: MyBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyBooks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyBooks'  is null.");
            }
            var myBooks = await _context.MyBooks.FindAsync(id);
            if (myBooks != null)
            {
                _context.MyBooks.Remove(myBooks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyBooksExists(int id)
        {
          return (_context.MyBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ReturnBook(int? id) {
            if (id == null) {
                return NotFound();
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null) {
                return NotFound();
            }

            var myBook = new Book {
                title = book.title,
                authorId = book.authorId,
                genreId = book.genreId,
            };

            _context.Books.Add(myBook);

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
