using MediaLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Interfaces;

public interface IVideoGameService
{
    Task<IEnumerable<VideoGame>> GetVideoGames();
    Task<VideoGame> GetById(Guid? id);
    Task<VideoGame> Create(VideoGame category);
    Task<VideoGame> Update(VideoGame category);
    Task<VideoGame> Remove(VideoGame category);
}
