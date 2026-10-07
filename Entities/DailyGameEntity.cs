using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_timeline_api.Entities;

public class DailyGameEntity
{
    [Key]
    public int DailyGameEntityID { get; set; }

    [ForeignKey(nameof(DailyGame))]
    public int DailyGameID { get; set; }

    [ForeignKey(nameof(Entity))]
    public int EntityID { get; set; }

    public virtual DailyGame? DailyGame { get; set; }

    public virtual Entity? Entity { get; set; }
}