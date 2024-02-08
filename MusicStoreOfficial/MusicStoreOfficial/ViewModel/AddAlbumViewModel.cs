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
        public List<Album> AlbumList { get; set; } = new List<Album>();
        public Album album { get; set; } = new Album { Nome = string.Empty };
        public string isAdded = "";

        private readonly IAlbumRepository _albumRepository;

        public AddAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
            AlbumList = _albumRepository.GetAllAlbunsAsync().Result;
        }

        public async Task HandleSubmit()
        {

            var add = await _albumRepository.AddAlbumAsync(album);
            isAdded = $"Album {add.Nome} Adicionado";
            //AlbumList.Add(album);
     





        }
    }
}
