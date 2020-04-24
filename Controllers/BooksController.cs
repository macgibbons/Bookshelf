using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Data;
using Bookshelf.Models;
using Bookshelf.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Books
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var items = await _context.Book
                     .Where(b => b.ApplicationUserId == user.Id)
                     .Include(b => b.BookGenres)
                     .ThenInclude(bg => bg.Genre)
                     .ToListAsync();

            return View(items);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new BookFormViewModel();

            var genreOptions = await _context.Genre
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToListAsync();

            viewModel.GenreOptions = genreOptions;

            return View(viewModel);
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookFormViewModel BookViewModel)
        {
            try
            {
                var book = new Book
                {
                    Title = BookViewModel.Title,
                    Author = BookViewModel.Author
                   
                };

                book.BookGenres = BookViewModel.SelectedGenreIds
                                  .Select(gId => new BookGenre()
                                  {
                                      Book = book,
                                      GenreId = gId
                                  }).ToList();


                var user = await GetCurrentUserAsync();
                book.ApplicationUserId = user.Id;

                _context.Book.Add(book);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}