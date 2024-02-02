using Microsoft.AspNetCore.Components;
using MusicStoreOfficial.Client.Services;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class AddAlbumViewModel : ViewModelBase
    {
        [SupplyParameterFromForm]
        public Album album { get; set; } = new Album { Nome = string.Empty };
        public string isAdded = "";

        private readonly IAlbumRepository _albumRepository;

        public AddAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task HandleSubmit()
        {
            var add = await _albumRepository.AddAlbumAsync(album);
            isAdded = $"Album {add.Nome} Adicionado";
        }
    }
}
