using ASPTute_Vidly.Models;
using ASPVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTute_Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}