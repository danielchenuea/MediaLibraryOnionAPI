using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Exceptions.Accounts;

public class AccountApiException : Exception
{
    public AccountApiException(string message) : base(message)
    {
        
    }
}
