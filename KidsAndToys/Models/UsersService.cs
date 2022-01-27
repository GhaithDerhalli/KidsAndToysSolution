using KidsAndToys.Models.Entities;
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
        KidsAndToysDBContext kidsAndToysDBContext;


        public UsersService(
            IdentityDbContext identityDBContext,
            KidsAndToysDBContext kidsAndToysDBContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            identityDBContext.Database.EnsureCreated();
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.kidsAndToysDBContext = kidsAndToysDBContext;
        }
        public async Task<string> TryRegisterAsync(CreateUserVM viewModel)
        {
            var result = await userManager.CreateAsync(new IdentityUser
            {
                UserName = viewModel.Username,
                Email = viewModel.Epost,
            }, viewModel.Password);
            bool createSucceeded = result.Succeeded;

            var query = kidsAndToysDBContext.Users.Add( new User
            {
                UserName = viewModel.Username,
                Epost = viewModel.Epost,
                PhoneNumber = viewModel.PhoneNumber,
                ZipCode = viewModel.ZipCode,
                Address = viewModel.Address,
                City = viewModel.City

            });
            kidsAndToysDBContext.SaveChanges();
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
