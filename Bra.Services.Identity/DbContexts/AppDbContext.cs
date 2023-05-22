using Bra.Services.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bra.Services.Identity.DbContexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        
    }
}
