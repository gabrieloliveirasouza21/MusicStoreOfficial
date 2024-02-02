using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpPost("addAlbum")]
        public async Task<ActionResult<Album>> AdicionarAlbum(Album album)
        {
            var albumAdded = await _albumRepository.AddAlbumAsync(album);
            return Ok(albumAdded);
        }

        [HttpGet("getAllAlbuns")]
        public async Task<ActionResult<List<Album>>> GetAllAbuns()
        {
            var getAll = await _albumRepository.GetAllAlbunsAsync();
            return Ok(getAll);
        }

        [HttpGet("getAlbumById/{id:int}")]
        public async Task<ActionResult<Album>> GetAlbumById(int id)
        {
            var getById = await _albumRepository.GetAlbumByIdAsync(id);
            return Ok(getById);
        }

        [HttpPut("updateAlbum")]
        public async Task<ActionResult<Album>> UpdateAlbum(Album album)
        {
            var updateAlbum = await _albumRepository.UpdateAlbumAsync(album);
            return Ok(updateAlbum);
        }

        [HttpDelete("deleteAlbum/{id:int}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var albumDeletado = await _albumRepository.DeleteAlbumAsync(id);
            return Ok(albumDeletado);
        }
    }
}
