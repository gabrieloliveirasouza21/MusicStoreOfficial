using Microsoft.AspNetCore.Components;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class EditAlbumViewModel : ViewModelBase
    {
        [SupplyParameterFromForm]
        public Album albumEditado { get; set; } = new Album() { Nome = string.Empty };
        [Parameter]
        public int Id { get; set; }
        public string isEdited = "";
        private readonly IAlbumRepository _albumRepository;

        public EditAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        public async Task<Album> HandleSubmit()
        {
            var albumComId = await _albumRepository.GetAlbumByIdAsync(Id);

            var albumEditado = await _albumRepository.UpdateAlbumAsync(albumComId);
            return albumEditado;
        }
    }
}
