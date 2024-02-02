using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public interface IAlbumRepository
    {
        Task<Album> AddAlbumAsync(Album album);
        Task<List<Album>> GetAllAlbunsAsync();
        Task<Album> GetAlbumByIdAsync(int id);
        Task<Album> UpdateAlbumAsync(Album album);
        Task<Album> DeleteAlbumAsync(int id);

    }
}
