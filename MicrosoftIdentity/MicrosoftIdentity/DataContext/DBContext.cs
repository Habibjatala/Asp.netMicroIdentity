
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicrosoftIdentity.Models;

namespace MicrosoftIdentity.DataContext
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
