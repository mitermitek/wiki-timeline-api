using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_timeline_api.Entities;

public class UserGameEntry
{
    [Key]
    public int UserGameEntryID { get; set; }

    [ForeignKey(nameof(UserGame))]
    public int UserGameID { get; set; }

    [ForeignKey(nameof(DailyGameEntity))]
    public int DailyGameEntityID { get; set; }

    public int Order { get; set; }

    public virtual UserGame? UserGame { get; set; }

    public virtual DailyGameEntity? DailyGameEntity { get; set; }
}