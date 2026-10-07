using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_timeline_api.Entities;

public class UserGame
{
    [Key]
    public int UserGameID { get; set; }

    [ForeignKey(nameof(DailyGame))]
    public int DailyGameID { get; set; }

    [ForeignKey(nameof(User))]
    public int UserID { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int? Score { get; set; }

    public virtual DailyGame? DailyGame { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserGameEntry> UserGameEntries { get; set; } = [];
}