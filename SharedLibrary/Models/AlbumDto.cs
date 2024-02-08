using MvvmBlazor;
using MvvmBlazor.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class AlbumDto : ViewModelBase
    {
        private int albumId;

        public int AlbumId
        {
            get { return albumId; }
            set => Set(ref albumId, value);
        }


        private string nome;

        public string Nome
        {
            get { return nome; }
            set => Set(ref nome, value);
        }


        private string genero;

        public string Genero
        {
            get { return genero; }
            set => Set(ref genero, value);
        }


        private string artista;

        public string Artista
        {
            get { return artista; }
            set => Set(ref artista, value);
        }


        private string imagem;

        public string Imagem
        {
            get { return imagem; }
            set => Set(ref imagem, value);
        }

    }
}
