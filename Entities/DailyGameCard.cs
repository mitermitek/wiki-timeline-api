using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wiki_timeline_api.Enums;

namespace wiki_timeline_api.Entities;

public class DailyGameCard
{
    [Key]
    public int DailyGameCardID { get; set; }

    [ForeignKey(nameof(DailyGame))]
    public int DailyGameID { get; set; }

    public int WikiID { get; set; }

    public required string WikiTitle { get; set; }

    public required string WikiImageUrl { get; set; }

    public required string WikiProperty { get; set; }

    public DateOnly EventDate { get; set; }

    public EventDateType EventDateType { get; set; }

    public virtual required DailyGame DailyGame { get; set; }
}