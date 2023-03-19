namespace CoolEventsSystem.Views.Administrator.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CoolEventsSystem.Data;
using CoolEventsSystem.Data.Models;

[Authorize(Roles = "Administrator")]
public class IndexModel : PageModel
{
	private ApplicationDbContext _context;

	public IndexModel(ApplicationDbContext context)
	{
		_context = context;
	}

	public List<User> Users { get; set; } = null!;

	public async Task<IActionResult> OnGetAsync()
	{
		if (User is null)
		{
			return RedirectToPage("/Home/Index");
		}

		Users = await _context.Users
			.Where(u => u.UserName != User.Identity.Name)
			.ToListAsync();

		return Page();
	}
}
