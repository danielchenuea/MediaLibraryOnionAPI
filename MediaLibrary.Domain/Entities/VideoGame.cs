
using MediaLibrary.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Domain.Entities;

public sealed class VideoGame : MediaBase
{
    public string Publisher { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public IList<string> Plataforms { get; set; } = new List<string>();
    public VideoGameTags Tags { get; set; }
    public float HoursPlayed { get; set; }

    public bool IsPlaying { get; set; }

    [ForeignKey("GroupId")]
    public Guid? GroupId { get; set; }
}
