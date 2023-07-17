using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> initialCategories = new List<Category>();
            initialCategories.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Pending Activities", Weight = 20 });
            initialCategories.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Personal Activities", Weight = 50 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);

                category.Property(p => p.Name).IsRequired().HasMaxLength(150);

                category.Property(p => p.Description).IsRequired(false);

                category.Property(p => p.Weight);

                category.HasData(initialCategories);
            });

            List<Models.Task> initialTasks = new List<Models.Task>();

            initialTasks.Add(new Models.Task() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), TaskPriority = Priority.Medium, Title = "Payment of utilities", CreationDate = DateTime.Now });
            initialTasks.Add(new Models.Task() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), TaskPriority = Priority.Low, Title = "Finish watching a movie on Netflix", CreationDate = DateTime.Now });

            modelBuilder.Entity<Models.Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);

                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

                task.Property(p => p.Title).IsRequired().HasMaxLength(200);

                task.Property(p => p.Description).IsRequired(false);

                task.Property(p => p.TaskPriority);

                task.Property(p => p.CreationDate);

                task.Ignore(p => p.Summary);

                task.HasData(initialTasks);
            });
        }
    }
}