namespace ServiceFleet.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using ServiceFleet.Data;
    using ServiceFleet.Data.Models;
    using ServiceFleet.Data.Models.Enums;

    [Authorize]
	public class BusesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public BusesController(
			ApplicationDbContext context,
			UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (User.IsInRole("Administrator"))
			{
                return View(await _context.Buses.ToListAsync());
            }

            if (User.IsInRole("Dispatcher"))
            {
                return View(await _context.Buses.ToListAsync());
            }

            if (User.IsInRole("Driver"))
            {
				var currentDriver = await _userManager
					.FindByNameAsync(User.Identity.Name);

                return View(await _context.Buses
					.Where(b => b.BusDriverId == currentDriver.Id)
					.ToListAsync());
            }

            return NotFound();
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Buses == null)
			{
				return NotFound();
			}

			var bus = await _context.Buses
				.FirstOrDefaultAsync(m => m.Id == id);

			if (bus == null)
			{
				return NotFound();
			}

			return View(bus);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Driver")]
		public async Task<IActionResult> Start(string id)
		{
			if (id == null || _context.Buses == null)
			{
				return NotFound();
			}

			var bus = await _context.Buses
				.FindAsync(id);

			if (bus is null)
			{
				return NotFound();
			}

			bus.Status = BusStatus.InProcess;

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize(Roles = "Dispatcher,Administrator")]
		public async Task<IActionResult> Create()
		{
            ViewBag["Drivers"] = await _userManager.GetUsersInRoleAsync("Driver");

            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Dispatcher,Administrator")]
        public async Task<IActionResult> Create(Bus bus)
		{
			bus.Status = BusStatus.Waiting;

			if (ModelState.IsValid)
			{
				_context.Add(bus);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(bus);
		}

		[HttpGet]
        [Authorize(Roles = "Dispatcher,Administrator")]
        public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.Buses == null)
			{
				return NotFound();
			}

			var bus = await _context.Buses
				.FindAsync(id);

			if (bus == null)
			{
				return NotFound();
			}

			return View(bus);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Dispatcher,Administrator")]
        public async Task<IActionResult> Edit(string id, Bus bus)
		{
			if (id != bus.Id)
			{
				return NotFound();
			}

            bus.Status = BusStatus.Waiting;

            if (ModelState.IsValid)
			{
				try
				{
					_context.Update(bus);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BusExists(bus.Id))
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

			return View(bus);
		}

		[HttpGet]
        [Authorize(Roles = "Dispatcher,Administrator")]
        public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.Buses == null)
			{
				return NotFound();
			}

			var bus = await _context.Buses
				.FirstOrDefaultAsync(m => m.Id == id);

			if (bus == null)
			{
				return NotFound();
			}

			return View(bus);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Dispatcher,Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.Buses == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Buses'  is null.");
			}
			var bus = await _context.Buses
				.FindAsync(id);

			if (bus is null)
			{
				return NotFound();
			}

			_context.Buses.Remove(bus);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool BusExists(string id)
		{
			return (_context.Buses?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
