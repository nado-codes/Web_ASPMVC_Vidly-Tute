using ASPTute_Vidly.Models;
using ASPVidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPTute_Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumInStock { get; set; }

        [DisplayName("Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public Genre Genre { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";
    }
}