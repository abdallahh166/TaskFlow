using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
