namespace Domain;

/// <summary>
/// Represents a following relationship between users
/// </summary>
public class UserFollowing
{
    /// <summary>
    /// Foreign key to the user who is following (observer)
    /// </summary>
    public string ObserverId { get; set; } = default!;
    
    /// <summary>
    /// User who is following (follower)
    /// </summary>
    public User Observer { get; set; } = null!;
    
    /// <summary>
    /// Foreign key to the user being followed (target)
    /// </summary>
    public string TargetId { get; set; } = default!;
    
    /// <summary>
    /// User being followed (followee)
    /// </summary>
    public User Target { get; set; } = null!;
}
