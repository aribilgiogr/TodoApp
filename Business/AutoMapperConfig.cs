using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;

namespace Business
{
    public static class AutoMapperConfig
    {
        private static IMapper mapper;

        public static IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    throw new Exception("Automapper başlatılmamış. Lütfen AutoMapperConfig.Initialize() metodunu çağırın.");
                }
                return mapper;
            }
        }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Todo, TodoDto>()
                   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

                cfg.CreateMap<TodoCreateDto, Todo>();
                cfg.CreateMap<CategoryCreateDto, Category>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<TodoCreateDto, TodoDto>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
    }
}
