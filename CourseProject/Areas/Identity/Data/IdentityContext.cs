using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseProject.Models;
using CourseProject.Areas.Identity.Data;

namespace CourseProject.Data
{
    public class IdentityContext : IdentityDbContext<AddFieldToUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
    }
}
