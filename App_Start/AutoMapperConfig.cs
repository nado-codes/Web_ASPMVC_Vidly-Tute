using ASPTute_Vidly.Models;
using ASPTute_Vidly.ViewModels;
using ASPVidly.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ASPTute_Vidly
{
    public class MissingMapException<S,D> : Exception
    {
        public MissingMapException() : base("Missing mapping for " + typeof(S).FullName + "<->" + typeof(D).FullName) { }
    }
    public class VidlyMapper
    {
        private static Mapper _mapper;

        public static void RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationDbContext, MovieFormViewModel>();
                cfg.CreateMap<ApplicationDbContext, CustomerFormViewModel>();
                cfg.CreateMap<Customer, Customer>();
                cfg.CreateMap<Movie, MovieFormViewModel>();
                cfg.CreateMap<Customer, CustomerFormViewModel>();
            });

            _mapper = new Mapper(config);
        }

        private static bool HasMap<S,D>()
        {
            var cfg = _mapper.ConfigurationProvider;

            foreach(TypeMap map in cfg.GetAllTypeMaps())
            {
                if (map.SourceType == typeof(S) && map.DestinationType == typeof(D))
                    return true;
            }

            return false;
        }

        public static D Map<S,D>(S source, D destination = default(D)) where D : new()
        {
            if(!HasMap<S,D>())
                throw new MissingMapException<S, D>();

            D mappedObject = _mapper.Map(source, (destination != null) ? destination : new D());

            return mappedObject;
        }
    }
}