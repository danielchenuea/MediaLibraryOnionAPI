using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Entities;

public abstract class MediaBase : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public int Score { get; set; }
    public bool Favorite { get; set; }

    //public virtual event EventHandler? MediaUpdated;
    //protected void OnMediaUpdated()
    //{
    //    MediaUpdated?.Invoke(this, EventArgs.Empty);
    //}
}
