using Microsoft.AspNetCore.Components;
using MusicStoreOfficial.Client.Services;
using MusicStoreOfficial.ViewModel;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;
using System.Collections.ObjectModel;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class AddAlbumViewModel : ViewModelBase
    {   
        public ObservableCollection<Album> AlbumList { get; set; } = new ObservableCollection<Album>();
        public Album album { get; set; } = new Album { Nome = string.Empty };
        public string isAdded = "";

        private readonly IAlbumRepository _albumRepository;
        private readonly NavigationManager _navigationManager;

        public AddAlbumViewModel(
            IAlbumRepository albumRepository,
            NavigationManager navigationManager)
        {
            _albumRepository = albumRepository;
            _navigationManager = navigationManager;
        }

        public async Task HandleSubmit()
        {

            var add = await _albumRepository.AddAlbumAsync(album);
            isAdded = $"Album {add.Nome} Adicionado";
            //AlbumList.Add(album);
            _navigationManager.NavigateTo("/");





        }
    }
}
