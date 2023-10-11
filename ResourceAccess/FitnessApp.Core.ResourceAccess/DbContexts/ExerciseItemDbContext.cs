using FitnessApp.Core.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace FitnessApp.Core.ResourceAccess.DbContexts
{
    public class ExerciseItemDbContext : DbContext
    {
        public ExerciseItemDbContext(DbContextOptions<ExerciseItemDbContext> options)
            : base(options)
        { }

        public DbSet<ExerciseItemModel> ExerciseItems { get; set; }

        public DbSet<WorkoutExercisesHistoryModel>  ExerciseItemsHistory { get; set; }

        public DbSet<ExerciseSetModel> ExerciseSets { get; set; }
    }
}
