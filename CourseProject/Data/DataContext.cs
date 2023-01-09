using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
