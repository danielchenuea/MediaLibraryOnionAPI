using MediaLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Interfaces;

public interface IRepositoryDbContext
{
    DbSet<Group> Groups { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<VideoGame> VideoGames { get; set; }

    Task<int> SaveChangesAsync();
}
