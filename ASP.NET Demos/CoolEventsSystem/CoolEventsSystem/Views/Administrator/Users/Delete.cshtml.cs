using CoolEventsSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolEventsSystem.Views.Administrator.Users
{
	[Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
		private ApplicationDbContext _context;

		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync(string userId)
        {
			if (User.IsInRole("Administrator"))
			{
				var userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);

				if (userToDelete is null)
				{
					return RedirectToPage("/NotFound");
				}

				_context.Users.Remove(userToDelete);
				await _context.SaveChangesAsync();

				return Page();
			}

			return RedirectToPage("/NotFound");
		}
    }
}
