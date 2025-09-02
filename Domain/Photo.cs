using System;
using System.Text.Json.Serialization;

namespace Domain;

/// <summary>
/// Represents a photo uploaded by a user
/// </summary>
public class Photo
{
    /// <summary>
    /// Unique identifier for the photo
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    /// <summary>
    /// URL of the photo
    /// </summary>
    public string Url { get; set; } = default!;
    
    /// <summary>
    /// Public ID from the cloud storage provider
    /// </summary>
    public string PublicId { get; set; } = default!;

    // Navigation properties
    /// <summary>
    /// Foreign key to the user who owns this photo
    /// </summary>
    public string UserId { get; set; } = default!;

    /// <summary>
    /// User who owns this photo
    /// </summary>
    [JsonIgnore]
    public User User { get; set; } = null!;
}
