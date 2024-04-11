using System.Linq.Expressions;

namespace Core.EFCore;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityCategory> ActivityCategories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Soft delete query filter
        ApplySoftDeleteQueryFilters(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    private void ApplySoftDeleteQueryFilters(ModelBuilder modelBuilder)
    {
        // Get BaseEntity's soft delete property name
        const string softDeletePropertyName = nameof(BaseEntity.DeleteAt);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var propertyMethodInfo = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(DateTime?));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(softDeletePropertyName));
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(null));
                var lambda = Expression.Lambda(compareExpression, parameter);

                // Apply
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }
}
