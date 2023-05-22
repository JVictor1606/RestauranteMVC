using Bra.Services.Identity.DbContexts;
using Bra.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using IdentityModel;
using System.Security.Claims;

namespace Bra.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            this._roleManager = roleManager;
        }

        public void Initializer()
        {
            if(_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser();
            {
                adminUser.UserName = "admin1@gmail.com";
                adminUser.Email = "admin1@gmail.com";
                adminUser.EmailConfirmed = true;
                adminUser.PhoneNumber = "111111111111";
                adminUser.FirstName = "Joao";
                adminUser.LastName = "Admin";
            }

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+ " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.FirstName),
                new Claim(JwtClaimTypes.Role,SD.Admin),
            }).Result;


            ApplicationUser customerUser = new ApplicationUser();
            {
                customerUser.UserName = "custumer1@gmail.com";
                customerUser.Email = "custumer@gmail.com";
                customerUser.EmailConfirmed = true;
                customerUser.PhoneNumber = "111111111111";
                customerUser.FirstName = "Joao";
                customerUser.LastName = "Custumer";
            }

            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,customerUser.FirstName+ " " + customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new Claim(JwtClaimTypes.Role,SD.Customer),
            }).Result;
        }
    }
}
