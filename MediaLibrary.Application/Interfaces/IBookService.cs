using MediaLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book> GetById(Guid? id);
    Task<Book> Create(Book category);
    Task<Book> Update(Book category);
    Task<Book> Remove(Book category);
}
