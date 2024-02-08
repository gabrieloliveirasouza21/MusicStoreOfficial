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

        private ObservableCollection<AlbumDto> albumList;

        public ObservableCollection<AlbumDto> AlbumList
        {
            get { return albumList; }
            set => Set(ref albumList,value);
        }


        public string isAdded = "";

        private readonly IAlbumRepository _albumRepository;

        public AddAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
            
        }

        public async Task HandleSubmit(AlbumDto albumDto)
        {
            var album = new Album
            {
                AlbumId = albumDto.AlbumId,
                Artista = albumDto.Artista,
                Genero = albumDto.Genero,
                Imagem = albumDto.Imagem,
                Nome = albumDto.Nome
            };

            var add = await _albumRepository.AddAlbumAsync(album);
            isAdded = $"Album {add.Nome} Adicionado";
            //AlbumList.Add(album);
     

        }

        public async Task IniciarListaAlbunsAsync()
        {
            var list = (await _albumRepository.GetAllAlbunsAsync()).Select(x => new AlbumDto
            {
                AlbumId = x.AlbumId,
                Artista = x.Artista,
                Genero = x.Genero,
                Imagem = x.Imagem,
                Nome = x.Nome
                
            }).ToList();
            AlbumList = new();

            foreach (var item in list)
            {
                AlbumList.Add(item);
            }
        }

       
    }
}
