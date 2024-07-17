using AutoMapper;
using BackendPieProject.Dtos;
using BackendPieProject.Models;

namespace BackendPieProject.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryReadDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Pie, PieReadDTO>();
            CreateMap<PieCreateDTO, Pie>();
        }
    }
}
