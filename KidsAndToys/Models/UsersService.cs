using KidsAndToys.Views.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KidsAndToys.Models
{
    public class UsersService
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public UsersService(
            IdentityDbContext identityDBContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            identityDBContext.Database.EnsureCreated();
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<string> TryRegisterAsync(CreateUserVM viewModel)
        {
            var result = await userManager.CreateAsync(new IdentityUser
            {
                UserName = viewModel.Username,
            }, viewModel.Password);
            return result.Errors.FirstOrDefault()?.Description;
        }

        public async Task<bool> TryLoginAsync(LogInVM viewModel)
        {
            var result = await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            return result.Succeeded;
        }
        internal async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
