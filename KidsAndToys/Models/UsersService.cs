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
        IWebHostEnvironment webHostEnv;

        public UsersService(
            IdentityDbContext identityDBContext,
            KidsAndToysDBContext kidsAndToysDBContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment webHostEnv
            )
        {
            identityDBContext.Database.EnsureCreated();
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.kidsAndToysDBContext = kidsAndToysDBContext;
            this.webHostEnv = webHostEnv;
        }
        public async Task<string> TryRegisterAsync(CreateUserVM viewModel)
        {
            if (viewModel.ProfilePic != null)
            {
                var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.ProfilePic.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                viewModel.ProfilePic.CopyTo(fileStream);
            }
                
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Epost,
                    PhoneNumber = viewModel.PhoneNumber,

                };
                var result = await userManager.CreateAsync(identityUser, viewModel.Password);
                bool createSucceeded = result.Succeeded;
            if (createSucceeded)
            {
                var query = kidsAndToysDBContext.Users.Add(new User
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Epost,
                    Id = identityUser.Id,
                    ZipCode = viewModel.ZipCode,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    ProfilePic = viewModel.ProfilePic?.FileName

                });
                kidsAndToysDBContext.SaveChanges();
            }
               
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
