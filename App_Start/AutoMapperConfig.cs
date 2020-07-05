using ASPTute_Vidly.Models;
using ASPTute_Vidly.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTute_Vidly
{
    public class VidlyMapper
    {
        private static Mapper _mapper;

        public static void RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationDbContext, MovieFormViewModel>();
                cfg.CreateMap<ApplicationDbContext, CustomerFormViewModel>();
            });

            _mapper = new Mapper(config);
        }

        public static D Map<S,D>(S source, D destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}