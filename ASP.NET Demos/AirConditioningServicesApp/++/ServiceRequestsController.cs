namespace AirConditioningServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirConditioningServices.Data;
using AirConditioningServices.Data.Models;
using AirConditioningServices.Data.Models.Enums;
using Microsoft.AspNetCore.Authorization;

public class ServiceRequestsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServiceRequestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ServiceRequests
    [Authorize]
    public async Task<IActionResult> Index()
    {
        return View(await _context.ServiceRequests.ToListAsync());
    }

    // GET: ServiceRequests/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
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

        return View(serviceRequest);
    }

    // GET: ServiceRequests/Create
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,ImageData,Status,TechVisitedDate")] ServiceRequest serviceRequest)
    {
        if (ModelState.IsValid)
        {
            _context.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        return View(serviceRequest);
    }

    // GET: ServiceRequests/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
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
    [Authorize]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,ImageData,Status,TechVisitedDate")] ServiceRequest serviceRequest)
    {
        if (id != serviceRequest.Id)
        {
            return NotFound();
        }

        serviceRequest.Status = RequestStatusEnum.Waiting;

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

    // GET: ServiceRequests/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
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

        return View(serviceRequest);
    }

    // POST: ServiceRequests/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.ServiceRequests == null)
        {
            return Problem("Entity set 'ApplicationDbContext.ServiceRequests'  is null.");
        }
        var serviceRequest = await _context.ServiceRequests.FindAsync(id);
        if (serviceRequest != null)
        {
            _context.ServiceRequests.Remove(serviceRequest);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool ServiceRequestExists(int id)
    {
        return _context.ServiceRequests.Any(e => e.Id == id);
    }
}
