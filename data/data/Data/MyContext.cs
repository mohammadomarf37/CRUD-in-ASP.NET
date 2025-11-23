using data.Models;
using Microsoft.EntityFrameworkCore;

namespace data.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Student> tbl_students { get; set; }
    }
}
