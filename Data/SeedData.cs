using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myapp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace myapp.Data
{
    public static class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Look for any biryanis.
            if (!context.Biryanis.Any())
            {
                context.Biryanis.AddRange(
                    new Biryani
                    {
                        Name = "Chicken Biryani",
                        Price = 450,
                        Description = "A classic and aromatic dish with tender chicken pieces cooked with basmati rice and a blend of spices.",
                        ImageUrl = "/images/chicken-biryani.jpg"
                    },

                    new Biryani
                    {
                        Name = "Mutton Biryani",
                        Price = 550,
                        Description = "A rich and flavorful Biryani with succulent mutton pieces that melt in your mouth.",
                        ImageUrl = "/images/mutton-biryani.jpg"
                    },

                    new Biryani
                    {
                        Name = "Vegetable Biryani",
                        Price = 350,
                        Description = "A delightful and healthy option with a mix of fresh vegetables and aromatic spices.",
                        ImageUrl = "/images/veg-biryani.jpg"
                    }
                );
                await context.SaveChangesAsync();
            }

            // Seed Roles and Admin User
            string adminRole = "Admin";
            string password = "kelly123";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await userManager.FindByNameAsync("milindar.j@ionidea.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "milindar.j@ionidea.com",
                    Email = "milindar.j@ionidea.com",
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }
        }
    }
}
