using Microsoft.EntityFrameworkCore;

namespace Domain;

/// <summary>
/// Represents an activity that users can attend
/// </summary>
[Index(nameof(Date))]
public class Activity
{
    /// <summary>
    /// Unique identifier for the activity
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    /// <summary>
    /// Activity title
    /// </summary>
    public string Title { get; set; } = default!;
    
    /// <summary>
    /// Date and time when the activity takes place
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Detailed description of the activity
    /// </summary>
    public string Description { get; set; } = default!;
    
    /// <summary>
    /// Activity category (e.g., music, culture, drinks, etc.)
    /// </summary>
    public string Category { get; set; } = default!;
    
    /// <summary>
    /// Indicates if the activity has been cancelled
    /// </summary>
    public bool IsCancelled { get; set; }

    // Location properties
    /// <summary>
    /// City where the activity takes place
    /// </summary>
    public string City { get; set; } = default!;
    
    /// <summary>
    /// Specific venue for the activity
    /// </summary>
    public string Venue { get; set; } = default!;
    
    /// <summary>
    /// Latitude coordinate of the venue
    /// </summary>
    public double Latitude { get; set; }
    
    /// <summary>
    /// Longitude coordinate of the venue
    /// </summary>
    public double Longitude { get; set; }

    // Navigation properties
    /// <summary>
    /// Collection of users attending this activity
    /// </summary>
    public ICollection<ActivityAttendee> Attendees { get; set; } = [];
    
    /// <summary>
    /// Collection of comments for this activity
    /// </summary>
    public ICollection<Comment> Comments { get; set; } = [];
}
