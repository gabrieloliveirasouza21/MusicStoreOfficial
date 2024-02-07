using Microsoft.AspNetCore.Components;
using MvvmBlazor.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace MusicStoreOfficial.Client.ViewModel
{
    public class DeleteAlbumViewModel : ViewModelBase
    {
        [Parameter]
        public int Id { get; set; }
        public string isDeleted = "";


        private readonly IAlbumRepository _albumRepository;

        public DeleteAlbumViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Album> DeleteAlbum()
        {
            var delete = await _albumRepository.DeleteAlbumAsync(Id);
            isDeleted = "Album deletado com sucesso";
            await Task.Delay(500);
            return delete;

        }
    }
}
