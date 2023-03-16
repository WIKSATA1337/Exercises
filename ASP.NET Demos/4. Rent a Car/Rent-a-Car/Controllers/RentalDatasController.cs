using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car.Data;
using Rent_a_Car.Data.Models;
using Rent_a_Car.Data.Models.Enums;

namespace Rent_a_Car.Controllers
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
                return View(await _context.RentalData
                    .Where(r => r.Status == RentalStatusEnums.Active)
                    .ToListAsync());
            }

            if (User.IsInRole("Administrator"))
            {
                return View(await _context.RentalData.ToListAsync());
            }

            return RedirectToPage("/Home/Index");
        }

        [HttpGet]
        [Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.RentalData == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
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
            var rental = await _context.RentalData
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
        public async Task<IActionResult> Rent(RentalData rentalData)
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
        [Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> Approve(string id)
        {
            var rental = await _context.RentalData
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
        public async Task<IActionResult> Approve(RentalData rentalData)
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
            ViewBag["CarIds"] = await _context.Cars
                .Select(c => c.Id)
                .ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(RentalData rentalData)
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
            if (id == null || _context.RentalData == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FindAsync(id);

            if (rentalData == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == rentalData.CarId);

            ViewBag["CarName"] = $"{car?.Make}  {car?.Model}";

            ViewBag["CarIds"] = await _context.Cars
                .Select(c => c.Id)
                .ToListAsync();

            return View(rentalData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id, RentalData rentalData)
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
            if (id == null || _context.RentalData == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (rentalData == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(c => c.Id == rentalData.CarId);

            ViewBag["CarName"] = $"{car?.Make}  {car?.Model}";

            return View(rentalData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.RentalData == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RentalData'  is null.");
            }

            var rentalData = await _context.RentalData
                .FindAsync(id);

            if (rentalData != null)
            {
                _context.RentalData.Remove(rentalData);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool RentalDataExists(string id)
        {
          return (_context.RentalData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
