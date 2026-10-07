using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using wiki_timeline_api.Enums;

namespace wiki_timeline_api.Entities;

[Index(nameof(ThemeID), nameof(ExternalID), nameof(DateType), IsUnique = true)]
public class Entity
{
    [Key]
    public int EntityID { get; set; }

    [ForeignKey(nameof(Theme))]
    public int ThemeID { get; set; }

    public required string ExternalID { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public int Year { get; set; }

    public DateType DateType { get; set; }

    public bool IsActive { get; set; } = false;

    public DateOnly? LastUsedAt { get; set; }

    public virtual Theme? Theme { get; set; }

    [InverseProperty(nameof(DailyGameEntity.Entity))]
    public virtual ICollection<DailyGameEntity> DailyGameEntities { get; set; } = [];
}