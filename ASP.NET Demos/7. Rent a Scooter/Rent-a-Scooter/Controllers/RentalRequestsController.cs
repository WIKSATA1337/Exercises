using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_a_Scooter.Data.Models.Enums;
using Rent_a_Scooter.Data.Models;
using Rent_a_Scooter.Data;
using System.Data;

namespace Rent_a_Scooter.Controllers
{
	[Authorize]
	public class RentalDatasController : Controller
	{
		private readonly ApplicationDbContext _context;

		public RentalDatasController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Authorize(Roles = "User,Administrator")]
		public async Task<IActionResult> Index()
		{
			if (User.IsInRole("User"))
			{
				return View(await _context.RentalRequests
					.Where(r => r.Status == RentalStatusEnums.Active)
					.ToListAsync());
			}

			if (User.IsInRole("Administrator"))
			{
				return View(await _context.RentalRequests.ToListAsync());
			}

			return RedirectToPage("/Home/Index");
		}

		[HttpGet]
		[Authorize(Roles = "User,Administrator")]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.RentalRequests == null)
			{
				return NotFound();
			}

			var rentalData = await _context.RentalRequests
				.FirstOrDefaultAsync(m => m.Id == id);

			if (rentalData == null)
			{
				return NotFound();
			}

			return View(rentalData);
		}

		[HttpGet]
		[Authorize(Roles = "User,Administrator")]
		public async Task<IActionResult> Rent(string id)
		{
			var rental = await _context.RentalRequests
				.FirstOrDefaultAsync(r => r.Id == id);

			if (rental is null)
			{
				return NotFound();
			}

			return View(rental);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "User,Administrator")]
		public async Task<IActionResult> Rent(RentalRequest rentalData)
		{
			rentalData.Status = RentalStatusEnums.Used;

			if (ModelState.IsValid)
			{
				_context.Update(rentalData);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(rentalData);
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Approve(string id)
		{
			var rental = await _context.RentalRequests
				.FirstOrDefaultAsync(r => r.Id == id);

			if (rental is null)
			{
				return NotFound();
			}

			return View(rental);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Approve(RentalRequest rentalData)
		{
			rentalData.Status = RentalStatusEnums.Active;

			if (ModelState.IsValid)
			{
				_context.Update(rentalData);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(rentalData);
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Create()
		{
			ViewBag["ScooterIds"] = await _context.Scooters
				.Select(c => c.Id)
				.ToListAsync();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Create(RentalRequest rentalData)
		{
			rentalData.Id = Guid.NewGuid().ToString();
			rentalData.Status = RentalStatusEnums.Waiting;

			if (ModelState.IsValid)
			{
				_context.Add(rentalData);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(rentalData);
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.RentalRequests == null)
			{
				return NotFound();
			}

			var rentalData = await _context.RentalRequests
				.FindAsync(id);

			if (rentalData == null)
			{
				return NotFound();
			}

			var scooter = await _context.Scooters
				.FirstOrDefaultAsync(c => c.Id == rentalData.ScooterId);

			ViewBag["ScooterIds"] = await _context.Scooters
				.Select(c => c.Id)
				.ToListAsync();

			return View(rentalData);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id, RentalRequest rentalData)
		{
			if (id != rentalData.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					rentalData.Status = RentalStatusEnums.Waiting;

					_context.Update(rentalData);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RentalDataExists(rentalData.Id))
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

			return View(rentalData);
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.RentalRequests == null)
			{
				return NotFound();
			}

			var rentalData = await _context.RentalRequests
				.FirstOrDefaultAsync(m => m.Id == id);

			if (rentalData == null)
			{
				return NotFound();
			}

			var scooter = await _context.Scooters
				.FirstOrDefaultAsync(c => c.Id == rentalData.ScooterId);

			return View(rentalData);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.RentalRequests == null)
			{
				return Problem("Entity set 'ApplicationDbContext.RentalRequests'  is null.");
			}

			var rentalData = await _context.RentalRequests
				.FindAsync(id);

			if (rentalData != null)
			{
				_context.RentalRequests.Remove(rentalData);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}

		private bool RentalDataExists(string id)
		{
			return (_context.RentalRequests?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
