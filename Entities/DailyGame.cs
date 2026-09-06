using System.ComponentModel.DataAnnotations;

namespace wiki_timeline_api.Entities;

public class DailyGame
{
    [Key]
    public int DailyGameID { get; set; }

    [DataType(DataType.Date)]
    public DateOnly CreationDate { get; set; }

    public virtual ICollection<DailyGameCard> DailyGameCards { get; set; } = [];
}