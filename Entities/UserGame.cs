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

    public int Attempts { get; set; }

    public int TimeTaken { get; set; }

    public int Score { get; set; }

    public virtual required DailyGame DailyGame { get; set; }
    public virtual required User User { get; set; }
}