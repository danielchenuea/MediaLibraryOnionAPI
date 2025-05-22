using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Exceptions.Accounts;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string error) : base(error) { }
}
