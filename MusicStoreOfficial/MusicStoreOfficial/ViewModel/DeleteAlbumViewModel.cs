using Microsoft.AspNetCore.Components;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class DeleteAlbumViewModel : ViewModelBase
    {
        //[Parameter]
        public int AlbumId { get; set; }
        public string isDeleted = "";


        private readonly IAlbumRepository _albumRepository;

        public DeleteAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Album> DeleteAlbum(int id)
        {
            var delete = await _albumRepository.DeleteAlbumAsync(id);
            isDeleted = "Album deletado com sucesso";
            return delete;

        }
    }
}
