using System.ComponentModel.DataAnnotations;

namespace wiki_timeline_api.Entities;

public class User
{
    [Key]
    public int UserID { get; set; }

    [MaxLength(50)]
    public required string Username { get; set; }

    [MaxLength(255)]
    [EmailAddress]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public virtual ICollection<UserGame> UserGames { get; set; } = [];
}