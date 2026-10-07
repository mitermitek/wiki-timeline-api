using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wiki_timeline_api.Entities;

[Index(nameof(CreationDate), IsUnique = true)]
public class DailyGame
{
    [Key]
    public int DailyGameID { get; set; }

    [DataType(DataType.Date)]
    public DateOnly CreationDate { get; set; }

    [InverseProperty(nameof(DailyGameEntity.DailyGame))]
    public virtual ICollection<DailyGameEntity> DailyGameEntities { get; set; } = [];
}