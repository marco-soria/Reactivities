namespace Domain;

/// <summary>
/// Represents the relationship between a user and an activity they attend
/// </summary>
public class ActivityAttendee
{
    /// <summary>
    /// Foreign key to the user attending the activity
    /// </summary>
    public string UserId { get; set; } = default!;
    
    /// <summary>
    /// User attending the activity
    /// </summary>
    public User User { get; set; } = null!;
    
    /// <summary>
    /// Foreign key to the activity being attended
    /// </summary>
    public string ActivityId { get; set; } = default!;
    
    /// <summary>
    /// Activity being attended
    /// </summary>
    public Activity Activity { get; set; } = null!;
    
    /// <summary>
    /// Indicates if this user is the host of the activity
    /// </summary>
    public bool IsHost { get; set; }
    
    /// <summary>
    /// Date when the user joined the activity
    /// </summary>
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;
}
