using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Repository.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClassroomManagementSystem.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassEntity> ClassEntities { get; set; }
        public DbSet<StudentExamResult> StudentExamResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var configurationTypes = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Configuration"));

            foreach (var configurationType in configurationTypes)
            {
                dynamic configuration = Activator.CreateInstance(configurationType);
                modelBuilder.ApplyConfiguration(configuration);
            }
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateChangeTracker();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            UpdateChangeTracker();
            return base.SaveChanges();
        }
        public void UpdateChangeTracker()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(entityReference).Property(x => x.UpdatedDate).IsModified = false;
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.IsDeleted = false;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
        }

    }
}
