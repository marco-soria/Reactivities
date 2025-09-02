using System;

namespace Domain;

/// <summary>
/// Represents a comment on an activity
/// </summary>
public class Comment
{
    /// <summary>
    /// Unique identifier for the comment
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    /// <summary>
    /// Content of the comment
    /// </summary>
    public string Body { get; set; } = default!;
    
    /// <summary>
    /// Timestamp when the comment was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    /// <summary>
    /// Foreign key to the user who wrote the comment
    /// </summary>
    public string UserId { get; set; } = default!;
    
    /// <summary>
    /// User who wrote the comment
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Foreign key to the activity this comment belongs to
    /// </summary>
    public string ActivityId { get; set; } = default!;
    
    /// <summary>
    /// Activity this comment belongs to
    /// </summary>
    public Activity Activity { get; set; } = null!;
}
