using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Exceptions.Accounts;

public class RegistrationErrorException : Exception
{
    public RegistrationErrorException(IEnumerable<IdentityError> errors) : base("Um erro de Registro ocorreu")
    {
        
    }
}
