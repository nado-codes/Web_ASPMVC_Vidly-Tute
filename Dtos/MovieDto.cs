﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPTute_Vidly.Models;

namespace ASPTute_Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        
        [Range(1, 20)]
        public byte NumInStock { get; set; }

        [DisplayName("Genre")]
        public byte GenreId { get; set; }
    }
}