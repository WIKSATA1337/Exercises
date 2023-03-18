using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rent_a_Scooter.Data;
using Rent_a_Scooter.Data.Models;

namespace Rent_a_Scooter.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;

        public RegisterModel(
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _context = appDbContext;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [MinLength(2)]
            [MaxLength(24)]
            public string Username { get; set; } = null!;

            [MinLength(6)]
            [MaxLength(24)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = null!;

            [MinLength(2)]
            [MaxLength(24)]
            public string FirstName { get; set; } = null!;

            [MinLength(2)]
            [MaxLength(24)]
            public string LastName { get; set; } = null!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (!_context.Users.Any())
                {
                    await InitializeAdministrator();
                }

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Username, CancellationToken.None);

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                var result = await _userManager.CreateAsync(user, Input.Password);

                await _userManager.AddToRoleAsync(user, "User");

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect("/Home/Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private async Task InitializeAdministrator()
        {
            if (!_context.Roles.Any())
            {
                await _context.Roles.AddAsync(new IdentityRole()
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                });

                await _context.Roles.AddAsync(new IdentityRole()
                {
                    Name = "Client",
                    NormalizedName = "CLIENT",
                });

                await _context.SaveChangesAsync();
            }

            var administrator = CreateUser();

            await _userStore.SetUserNameAsync(administrator, "Administrator", CancellationToken.None);

            administrator.FirstName = "Administrator";
            administrator.LastName = "Administrator";

            var result = await _userManager.CreateAsync(administrator, "123456");

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Administrator was not initialized.");
            }

            await _userManager.AddToRoleAsync(administrator, "Administrator");
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
