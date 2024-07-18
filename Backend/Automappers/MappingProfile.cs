using AutoMapper;
using Backend.DTOs;
using Backend.Models;
namespace Backend.Automappers

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //cuando el origen tiene los mismos nombres que el destino
            CreateMap<BeerInsertDto, Beer>();
            //cuando el origen tiene diferentes nombres que el destino
            //ForMember es para mapear un campo a otro
            CreateMap<Beer, BeerDto>().
                ForMember(dto => dto.Id,
                          m => m.MapFrom(b => b.BeerID));
            //Cuando es un objeto existente
            CreateMap<BeerUpdateDto, Beer>();
        }
    }
}
