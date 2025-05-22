using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Entities;

public class Book : MediaBase
{
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Pages { get; set; }

    public bool IsReading { get; set; }

    [ForeignKey("GroupId")]
    public Guid? GroupId { get; set; }
}
