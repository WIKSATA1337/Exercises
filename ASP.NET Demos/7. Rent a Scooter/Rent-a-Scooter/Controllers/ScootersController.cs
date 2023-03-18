using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_a_Scooter.Data;
using Rent_a_Scooter.Data.Models;

namespace Rent_a_Scooter.Controllers
{
	[Authorize(Roles = "Administrator")]
	public class ScootersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ScootersController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Scooters.ToListAsync());
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Scooters == null)
			{
				return NotFound();
			}

			var scooter = await _context.Scooters
				.FirstOrDefaultAsync(m => m.Id == id);

			if (scooter == null)
			{
				return NotFound();
			}

			return View(scooter);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Scooter scooter)
		{
			scooter.Id = Guid.NewGuid().ToString();

			if (ModelState.IsValid)
			{
				_context.Add(scooter);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(scooter);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.Scooters == null)
			{
				return NotFound();
			}

			var scooter = await _context.Scooters
				.FindAsync(id);

			if (scooter == null)
			{
				return NotFound();
			}

			return View(scooter);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, Scooter scooter)
		{
			if (id != scooter.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(scooter);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CarExists(scooter.Id))
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

			return View(scooter);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.Scooters == null)
			{
				return NotFound();
			}

			var scooter = await _context.Scooters
				.FirstOrDefaultAsync(m => m.Id == id);

			if (scooter == null)
			{
				return NotFound();
			}

			return View(scooter);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.Scooters == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Scooters'  is null.");
			}

			var scooter = await _context.Scooters
				.FindAsync(id);

			if (scooter != null)
			{
				_context.Scooters.Remove(scooter);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}

		private bool CarExists(string id)
		{
			return (_context.Scooters?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
