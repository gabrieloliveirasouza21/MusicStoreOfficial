using MvvmBlazor.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Artista { get; set; }
        [Required]
        public string Imagem { get; set; }
    }
}
