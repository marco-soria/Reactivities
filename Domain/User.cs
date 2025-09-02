using Microsoft.AspNetCore.Identity;

namespace Domain;

/// <summary>
/// Represents a user in the system, extending IdentityUser
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// Display name shown to other users
    /// </summary>
    public string? DisplayName { get; set; }
    
    /// <summary>
    /// User's biography or description
    /// </summary>
    public string? Bio { get; set; }
    
    /// <summary>
    /// URL to the user's profile image
    /// </summary>
    public string? ImageUrl { get; set; }

    // Navigation properties
    /// <summary>
    /// Activities this user is attending
    /// </summary>
    public ICollection<ActivityAttendee> Activities { get; set; } = [];
    
    /// <summary>
    /// Photos uploaded by this user
    /// </summary>
    public ICollection<Photo> Photos { get; set; } = [];
    
    /// <summary>
    /// Users that this user is following
    /// </summary>
    public ICollection<UserFollowing> Followings { get; set; } = [];
    
    /// <summary>
    /// Users that are following this user
    /// </summary>
    public ICollection<UserFollowing> Followers { get; set; } = [];
}
