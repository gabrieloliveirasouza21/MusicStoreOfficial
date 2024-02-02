using SharedLibrary.Models;
using SharedLibrary.Repositories;
using System.Net.Http.Json;

namespace MusicStoreOfficial.Client.Services
{
    public class AlbumService : IAlbumRepository
    {
        private readonly HttpClient _httpClient;

        public AlbumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Album> AddAlbumAsync(Album album)
        {
            var prod = await _httpClient.PostAsJsonAsync("api/Album/addAlbum", album);
            var res = await prod.Content.ReadFromJsonAsync<Album>();
            return res!;
        }

        public async Task<Album> DeleteAlbumAsync(int id)
        {
            var prod = await _httpClient.DeleteAsync($"api/Album/deleteAlbum/{id}");
            var res = await prod.Content.ReadFromJsonAsync<Album>();
            return res!;
        }

        public async Task<List<Album>> GetAllAlbunsAsync()
        {
            var prod = await _httpClient.GetAsync("api/Album/allAlbum");
            var res = await prod.Content.ReadFromJsonAsync<List<Album>>();
            return res!;

        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var prod = await _httpClient.GetAsync($"api/Album/getAlbumById/{id}");
            var res = await prod.Content.ReadFromJsonAsync<Album>();
            return res!;

        }

        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            var prod = await _httpClient.PutAsJsonAsync("api/Produto/updateProd", album);
            var res = await prod.Content.ReadFromJsonAsync<Album>();
            return res!;

        }
    }
}
