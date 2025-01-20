using TaskFlowBackend.Models;
using TaskFlowBackend.Data;

public static class SeedDatabase
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Check if the database is already seeded
        if (!context.Users.Any())
        {
            // Add default users (optional)
            context.Users.AddRange(
                new User { Username = "admin", Password = "admin123",},
                new User { Username = "user", Password = "password123",}
            );
            context.SaveChanges();
        }
    }
}
