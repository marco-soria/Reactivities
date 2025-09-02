using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence;

/// <summary>
/// Application database context extending IdentityDbContext
/// </summary>
public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    /// <summary>
    /// Activities in the system
    /// </summary>
    public DbSet<Activity> Activities { get; set; } = null!;
    
    /// <summary>
    /// Activity attendees relationship table
    /// </summary>
    public DbSet<ActivityAttendee> ActivityAttendees { get; set; } = null!;
    
    /// <summary>
    /// Photos uploaded by users
    /// </summary>
    public DbSet<Photo> Photos { get; set; } = null!;
    
    /// <summary>
    /// Comments on activities
    /// </summary>
    public DbSet<Comment> Comments { get; set; } = null!;
    
    /// <summary>
    /// User following relationships
    /// </summary>
    public DbSet<UserFollowing> UserFollowings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Activity entity
        builder.Entity<Activity>(entity =>
        {
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            entity.Property(e => e.City).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Venue).IsRequired().HasMaxLength(500);
            entity.HasIndex(e => e.Date);
        });

        // Configure Comment entity
        builder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Body).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.ActivityId).IsRequired();
        });

        // Configure Photo entity
        builder.Entity<Photo>(entity =>
        {
            entity.Property(e => e.Url).IsRequired().HasMaxLength(500);
            entity.Property(e => e.PublicId).IsRequired().HasMaxLength(200);
            entity.Property(e => e.UserId).IsRequired();
        });

        // Configure ActivityAttendee many-to-many relationship
        builder.Entity<ActivityAttendee>(entity => 
        {
            entity.HasKey(a => new { a.ActivityId, a.UserId });
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.ActivityId).IsRequired();
        });

        builder.Entity<ActivityAttendee>()
            .HasOne(x => x.User)
            .WithMany(x => x.Activities)
            .HasForeignKey(x => x.UserId);

        builder.Entity<ActivityAttendee>()
            .HasOne(x => x.Activity)
            .WithMany(x => x.Attendees)
            .HasForeignKey(x => x.ActivityId);

        // Configure UserFollowing many-to-many relationship
        builder.Entity<UserFollowing>(entity => 
        {
            entity.HasKey(k => new {k.ObserverId, k.TargetId});
            entity.Property(e => e.ObserverId).IsRequired();
            entity.Property(e => e.TargetId).IsRequired();

            entity.HasOne(o => o.Observer)
                .WithMany(f => f.Followings)
                .HasForeignKey(o => o.ObserverId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(o => o.Target)
                .WithMany(f => f.Followers)
                .HasForeignKey(o => o.TargetId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // Configure DateTime conversion to UTC
        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        );

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
            }
        }
    }
}
