using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime DateInsert { get; set; }
    public DateTime DateEdit { get; set; }
}
