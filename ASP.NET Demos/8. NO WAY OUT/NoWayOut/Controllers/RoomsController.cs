namespace NoWayOut.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using NoWayOut.Data;
	using NoWayOut.Data.Models;

	[Authorize(Roles = "Administrator")]
	public class RoomsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public RoomsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Rooms.ToListAsync());
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Rooms == null)
			{
				return NotFound();
			}

			var room = await _context.Rooms
				.FirstOrDefaultAsync(m => m.Id == id);

			if (room == null)
			{
				return NotFound();
			}

			return View(room);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Room room)
		{
			ModelState.Remove("Image");

			if (ModelState.IsValid)
			{
				_context.Add(room);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(room);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.Rooms == null)
			{
				return NotFound();
			}

			var room = await _context.Rooms
				.FindAsync(id);

			if (room == null)
			{
				return NotFound();
			}

			return View(room);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, Room room)
		{
			if (id != room.Id)
			{
				return NotFound();
			}

            ModelState.Remove("Image");

            if (ModelState.IsValid)
			{
				try
				{
					_context.Update(room);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RoomExists(room.Id))
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

			return View(room);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.Rooms == null)
			{
				return NotFound();
			}

			var room = await _context.Rooms
				.FirstOrDefaultAsync(m => m.Id == id);

			if (room == null)
			{
				return NotFound();
			}

			return View(room);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.Rooms == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
			}

			var room = await _context.Rooms
				.FindAsync(id);

			if (room is null)
			{
				return NotFound();
			}

			_context.Rooms.Remove(room);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool RoomExists(string id)
		{
			return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
