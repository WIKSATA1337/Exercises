using AirConditioningServices.Data;
using AirConditioningServices.Data.Models;
using AirConditioningServices.Data.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirConditioningServices.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministratorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sr = await _context.ServiceRequests
                .Where(sr => sr.Status == ServiceStatuses.Waiting)
                .ToListAsync();

            return View(sr);
        }

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Decline(string id)
		{
			if (_context.ServiceRequests == null)
			{
				return Problem("Entity set 'ApplicationDbContext.ServiceRequests'  is null.");
			}

			var serviceRequest = await _context.ServiceRequests
				.FindAsync(id);

			if (serviceRequest == null)
			{
				return NotFound();
			}

			_context.ServiceRequests.Remove(serviceRequest);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Approve(string id)
		{
			if (_context.ServiceRequests == null)
			{
				return Problem("Entity set 'ApplicationDbContext.ServiceRequests'  is null.");
			}

			var serviceRequest = await _context.ServiceRequests
				.FindAsync(id);

			if (serviceRequest == null)
			{
				return NotFound();
			}

			serviceRequest.Status = ServiceStatuses.WaitingVisit;
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.ServiceRequests == null)
			{
				return NotFound();
			}

			var serviceRequest = await _context.ServiceRequests.FindAsync(id);

			if (serviceRequest == null)
			{
				return NotFound();
			}

			return View(serviceRequest);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Address,Image,Status,VisitedDate,CreatedById")] ServiceRequest serviceRequest)
		{
			if (id != serviceRequest.Id)
			{
				return NotFound();
			}

			serviceRequest.Status = ServiceStatuses.Waiting;
			serviceRequest.VisitedDate = null;
			serviceRequest.Image = new byte[1];

			ModelState.Remove("Image");
			ModelState.Remove("VisitedDate");

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(serviceRequest);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ServiceRequestExists(serviceRequest.Id))
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
			return View(serviceRequest);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null || _context.ServiceRequests == null)
			{
				return NotFound();
			}

			var serviceRequest = await _context.ServiceRequests
				.FirstOrDefaultAsync(m => m.Id == id);

			if (serviceRequest == null)
			{
				return NotFound();
			}

			if (serviceRequest.Status != ServiceStatuses.Waiting)
			{
				return RedirectToPage("/ServiceRequests/Index");
			}

			return View(serviceRequest);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			if (_context.ServiceRequests == null)
			{
				return Problem("Entity set 'ApplicationDbContext.ServiceRequests'  is null.");
			}
			var serviceRequest = await _context.ServiceRequests.FindAsync(id);
			if (serviceRequest == null)
			{
				return NotFound();
			}

			_context.ServiceRequests.Remove(serviceRequest);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool ServiceRequestExists(string id)
		{
			return (_context.ServiceRequests?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
