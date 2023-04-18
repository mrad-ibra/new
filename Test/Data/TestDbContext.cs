using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options):base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
