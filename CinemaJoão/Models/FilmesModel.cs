using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaJoão.Models
{
    public class FilmesModel
    {
        public  Guid Id { get; set; }

        [Required]
        public string Filme { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Ano { get; set; }
        
        public string LinkImg { get; set; }


        public FilmesModel()
        {
            Id = Guid.NewGuid();
        }


    }
}
