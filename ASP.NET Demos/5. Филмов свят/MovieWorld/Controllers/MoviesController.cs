namespace MovieWorld.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using MovieWorld.Data;
	using MovieWorld.Data.Models;

    [Authorize]
	public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Movies.ToListAsync());
        }

		[HttpGet]
		public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCatalog(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            ViewBag["Catalogs"] = _context.Catalogs
                .Where(c => c.CreatedBy == currentUser.Id)
                .ToList();

            return RedirectToAction("AddToCatalog", "Movies", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCatalog(string id, string name)
        {
            var Movie = _context.Movies
                .First(m => m.Id == id);

            var Catalog = _context.Catalogs
                .First(c => c.Name == name);

            Catalog.Movies.Add(Movie);

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

        [HttpGet]
        [Authorize(Roles = "Administrator")]
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Create(Movie movie)
        {
            movie.Image = new byte[1];
            ModelState.Remove("Image");

            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            movie.Image = new byte[1];
            ModelState.Remove("Image");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            
            return View(movie);
        }

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies
                .FindAsync(id);

            if (movie is null)
            {
                return NotFound();
            }
            
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(string id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
