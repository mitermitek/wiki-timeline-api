using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_timeline_api.Entities;

public class Theme
{
    [Key]
    public int ThemeID { get; set; }

    public required string Name { get; set; }

    public bool IsActive { get; set; } = false;

    [InverseProperty(nameof(Entity.Theme))]
    public virtual ICollection<Entity> Entities { get; set; } = [];
}