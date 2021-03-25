using AdvancePagination.Demo.DTO;
using AdvancePagination.Demo.Models;
using AutoMapper;

namespace AdvancePagination.Demo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDTO>(); //Map from Post to PostDTO.
        }
    }
}
