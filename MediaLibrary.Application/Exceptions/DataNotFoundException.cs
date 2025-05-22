using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Exceptions;

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string message) : base(message)
    {
        
    }

    public static DataNotFoundException New(string column) => new($"{column} could not be found");
}
