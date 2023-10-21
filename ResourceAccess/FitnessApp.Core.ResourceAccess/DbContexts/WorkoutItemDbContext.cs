using Microsoft.EntityFrameworkCore;
using FitnessApp.Core.ResourceAccess.Models;

namespace FitnessApp.Core.ResourceAccess.DbContexts
{
    public class WorkoutItemDbContext : DbContext
    {
        public WorkoutItemDbContext(DbContextOptions<WorkoutItemDbContext> options) 
            : base(options)
        {  }

        public DbSet<WorkoutItemModel> WorkoutItem { get; set; }

        public DbSet<WorkoutExercisesHistoryModel> WorkoutExercisesHistory { get; set; }
    }
}
