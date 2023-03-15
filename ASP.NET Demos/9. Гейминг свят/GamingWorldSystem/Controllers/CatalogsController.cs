using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingWorldSystem.Data;
using GamingWorldSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace GamingWorldSystem.Controllers
{
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
			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

			var catalogs = await _context.Catalog
				.Where(c => c.CreatedBy == currentUser.Id)
				.ToListAsync();


			return View(catalogs);
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Catalog == null)
			{
				return NotFound();
			}

			var catalog = await _context.Catalog
				.FirstOrDefaultAsync(m => m.Id == id);

			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

			if (catalog == null)
			{
				return NotFound();
			}

			if (catalog.CreatedBy != currentUser.Id)
			{
				return NotFound();
			}

			return View(catalog);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description,CreatedBy")] Catalog catalog)
		{
			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

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
			if (id == null || _context.Catalog == null)
			{
				return NotFound();
			}

			var catalog = await _context.Catalog.FindAsync(id);

			if (catalog == null)
			{
				return NotFound();
			}

			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

			if (catalog.CreatedBy != currentUser.Id)
			{
				return NotFound();
			}

			return View(catalog);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,CreatedBy")] Catalog catalog)
		{
			if (id != catalog.Id)
			{
				return NotFound();
			}

			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

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
			if (id == null || _context.Catalog == null)
			{
				return NotFound();
			}

			var catalog = await _context.Catalog
				.FirstOrDefaultAsync(m => m.Id == id);

			if (catalog == null)
			{
				return NotFound();
			}

			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

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
			if (_context.Catalog == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Catalog'  is null.");
			}

			var catalog = await _context.Catalog.FindAsync(id);

			if (catalog == null)
			{
				return NotFound();
			}

			User currentUser = await _context.Users
				.AsNoTracking()
				.FirstAsync(u => u.UserName == User.Identity.Name);

			if (catalog.CreatedBy != currentUser.Id)
			{
				return NotFound();
			}

			_context.Catalog.Remove(catalog);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool CatalogExists(string id)
		{
			return _context.Catalog.Any(e => e.Id == id);
		}
	}
}
