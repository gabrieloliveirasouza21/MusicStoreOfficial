using Microsoft.AspNetCore.Components;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class EditAlbumViewModel : ViewModelBase
    {
        public Album albumEditado { get; set; } = new Album() { Nome = string.Empty };
        public int Id { get; set; }
        public string isEdited = "";
        private readonly IAlbumRepository _albumRepository;

        public EditAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        public async Task<Album> HandleSubmit()
        {
            albumEditado.AlbumId = Id;
            var albumEdit = await _albumRepository.UpdateAlbumAsync(albumEditado);
            isEdited = "Album Editado";
            return albumEditado;
        }
    }
}
