namespace CoolEventsSystem.Views.Administrator.Users;

using CoolEventsSystem.Data;
using CoolEventsSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize(Roles = "Administrator")]
public class IndexModel : PageModel
{
	private ApplicationDbContext _context;
	private UserManager<User> _userManager;

	public IndexModel(ApplicationDbContext context,
		UserManager<User> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	public List<User> Users { get; set; }

	public async Task<IActionResult> OnGet()
	{
		if (User is null)
		{
			return RedirectToPage("/Home/Index");
		}

		Users = _context.Users
			.Where(u => u.UserName != User.Identity.Name)
			.ToList();

		return Page();
	}
}
