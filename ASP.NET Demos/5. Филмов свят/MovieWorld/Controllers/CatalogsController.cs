namespace MovieWorld.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using MovieWorld.Data;
    using MovieWorld.Data.Models;

    [Authorize]
    public class CatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            return View(await _context.Catalogs
                .Where(c => c.CreatedBy == currentUser.Id)
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (catalog == null)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            if (catalog.CreatedBy != currentUser.Id)
            {
                return NotFound();
            }

            ViewBag["MovieNames"] = catalog.Movies
                .Select(m => m.Name)
                .ToList();

            return View(catalog);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Catalog catalog)
        {
			var currentUser = _context.Users
				.First(u => u.UserName == User.Identity.Name);

            catalog.CreatedBy = currentUser.Id;

			if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .FindAsync(id);

            if (catalog == null)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            if (catalog.CreatedBy != currentUser.Id)
            {
                return NotFound();
            }

            return View(catalog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            if (catalog.CreatedBy != currentUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.Id))
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

            return View(catalog);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (catalog is null)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            if (catalog.CreatedBy != currentUser.Id)
            {
                return NotFound();
            }

            return View(catalog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Catalogs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Catalogs'  is null.");
            }

            var catalog = await _context.Catalogs
                .FindAsync(id);

            if (catalog is null)
            {
                return NotFound();
            }

            var currentUser = _context.Users
                .First(u => u.UserName == User.Identity.Name);

            if (catalog.CreatedBy != currentUser.Id)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(string id)
        {
            return (_context.Catalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
