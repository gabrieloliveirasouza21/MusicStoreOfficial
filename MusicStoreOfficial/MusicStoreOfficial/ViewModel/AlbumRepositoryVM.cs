using Microsoft.EntityFrameworkCore;
using MusicStoreOfficial.DataContext;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.ViewModel
{
    public class AlbumRepositoryVM : IAlbumRepository
    {
        private readonly DbCtx _dbCtx;

        public AlbumRepositoryVM(DbCtx dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<Album> AddAlbumAsync(Album album)
        {
            if (album is null) return null!;
            var albumAdded = _dbCtx.Albuns.Add(album).Entity;
            await _dbCtx.SaveChangesAsync();
            return albumAdded;
        }

        public async Task<Album> DeleteAlbumAsync(int id)
        {
            var albumDelete = await _dbCtx.Albuns.FirstOrDefaultAsync(album => album.AlbumId == id);
            if (albumDelete is null) return null!;
            _dbCtx.Albuns.Remove(albumDelete);
            await _dbCtx.SaveChangesAsync();
            return albumDelete;
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var prodById = await _dbCtx.Albuns.FirstOrDefaultAsync(prod => prod.AlbumId == id);
            if (prodById is null) return null!;
            return prodById;
            
        }

        public async Task<List<Album>> GetAllAlbunsAsync() => await _dbCtx.Albuns.ToListAsync();
        

        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            var prod = await _dbCtx.Albuns.FirstOrDefaultAsync(prod => prod.AlbumId == album.AlbumId);
            if (prod is null) return null!;
            prod.Nome = album.Nome;
            prod.Artista = album.Artista;
            prod.Imagem = album.Imagem;
            prod.Genero = album.Genero;
            await _dbCtx.SaveChangesAsync();
            return await _dbCtx.Albuns.FirstOrDefaultAsync(_ => _.AlbumId == album.AlbumId);
        }
    }
}
