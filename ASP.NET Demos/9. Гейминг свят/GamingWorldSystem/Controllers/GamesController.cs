using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingWorldSystem.Data;
using GamingWorldSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace GamingWorldSystem.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
		public async Task<IActionResult> Index()
        {
              return View(await _context.Games.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
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
		public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,PremierDate")] Game game)
        {
            game.Image = new byte[1];
			ModelState.Remove("Image");

			if (ModelState.IsValid)
            {
                await _context.AddAsync(game);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Image,PremierDate")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

			ModelState.Remove("Image");

			if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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

            return View(game);
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Games'  is null.");
            }

            var game = await _context.Games.FindAsync(id);

            if (game != null)
            {
                _context.Games.Remove(game);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(string id)
        {
          return _context.Games.Any(e => e.Id == id);
        }
    }
}
