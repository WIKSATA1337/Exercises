namespace NoWayOut.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NoWayOut.Data;
    using NoWayOut.Data.Models;
    using NoWayOut.Data.Models.Enums;

    [Authorize]
    public class RoomRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Client,Administrator")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View(await _context.RoomRequests.ToListAsync());
            }

            if (User.IsInRole("Client"))
            {
                return View(await _context.RoomRequests
                    .Where(rr => rr.Status == RoomStatus.Active)
                    .ToListAsync());
            }

            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "Client,Administrator")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.RoomRequests == null)
            {
                return NotFound();
            }

            var roomRequest = await _context.RoomRequests
                .FirstOrDefaultAsync(m => m.Id == id);

            if (roomRequest == null)
            {
                return NotFound();
            }

            return View(roomRequest);
        }

        [HttpGet]
        [Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> RequestRoom(string id)
        {
            var rental = await _context.RoomRequests
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
        public async Task<IActionResult> RequestRoom(RoomRequest rentalData)
        {
            rentalData.Status = RoomStatus.Used;

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
            var rental = await _context.RoomRequests
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
        public async Task<IActionResult> Approve(RoomRequest rentalData)
        {
            rentalData.Status = RoomStatus.Active;

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(RoomRequest roomRequest)
        {
            roomRequest.Status = RoomStatus.Waiting;

            if (ModelState.IsValid)
            {
                _context.Add(roomRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(roomRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.RoomRequests == null)
            {
                return NotFound();
            }

            var roomRequest = await _context.RoomRequests
                .FindAsync(id);

            if (roomRequest == null)
            {
                return NotFound();
            }

            return View(roomRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id, RoomRequest roomRequest)
        {
            if (id != roomRequest.Id)
            {
                return NotFound();
            }

            roomRequest.Status = RoomStatus.Waiting;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomRequestExists(roomRequest.Id))
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

            return View(roomRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.RoomRequests == null)
            {
                return NotFound();
            }

            var roomRequest = await _context.RoomRequests
                .FirstOrDefaultAsync(m => m.Id == id);

            if (roomRequest == null)
            {
                return NotFound();
            }

            return View(roomRequest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.RoomRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RoomRequests'  is null.");
            }
            var roomRequest = await _context.RoomRequests
                .FindAsync(id);

            if (roomRequest is null)
            {
                return NotFound();
            }

            _context.RoomRequests.Remove(roomRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RoomRequestExists(string id)
        {
          return (_context.RoomRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
