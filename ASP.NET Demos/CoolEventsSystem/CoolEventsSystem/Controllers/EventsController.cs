using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoolEventsSystem.Data;
using CoolEventsSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoolEventsSystem.Controllers
{
	public class EventsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public EventsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Events.ToListAsync());
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Details(string id)
		{
			if (id == null || _context.Events == null)
			{
				return NotFound();
			}

			var @event = await _context.Events
				.FirstOrDefaultAsync(m => m.Id == id);
			if (@event == null)
			{
				return NotFound();
			}

			return View(@event);
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
		public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,EventDate")] Event @event, IFormFile Image)
		{
			try
			{
				using (MemoryStream ms = new MemoryStream())
				{
					Image.CopyTo(ms);

					@event.Image = ms.ToArray();
				}

				ModelState.Remove("Image");

				if (ModelState.IsValid)
				{
					_context.Add(@event);
					await _context.SaveChangesAsync();

					return RedirectToAction(nameof(Index));
				}

				return View(@event);
			}
			catch
			{
				return NotFound();
			}
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.Events == null)
			{
				return NotFound();
			}

			var @event = await _context.Events.FindAsync(id);
			if (@event == null)
			{
				return NotFound();
			}

			return View(@event);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Image,EventDate")] Event @event)
		{
			if (id != @event.Id)
			{
				return NotFound();
			}

			ModelState.Remove("Image");

            if (ModelState.IsValid)
			{
				try
				{
					_context.Update(@event);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EventExists(@event.Id))
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

			return View(@event);
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.Events == null)
			{
				return NotFound();
			}

			var @event = await _context.Events
				.FirstOrDefaultAsync(m => m.Id == id);

			if (@event == null)
			{
				return NotFound();
			}

			return View(@event);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.Events == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Events' is null.");
			}

			var @event = await _context.Events.FindAsync(id);

			if (@event != null)
			{
				_context.Events.Remove(@event);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool EventExists(string id)
		{
			return _context.Events.Any(e => e.Id == id);
		}
	}
}
