using AutoMapper;
using TravelApp.Models;
using TravelApp.Contracts.List.Request;
using System.Collections.Generic;

public class ListMappingProfile : Profile
{
    public ListMappingProfile()
    {
        // Mapiranje između ListCreateDTO i List modela
        CreateMap<ListCreateDTO, List>()
            .ForMember(dest => dest.Slika, opt => opt.Ignore()); // Ako ne želite da mapirate određeno polje, koristite Ignore

        // Mapiranje između ListUpdateDTO i List modela
        CreateMap<ListUpdateDTO, List>()
            .ForMember(dest => dest.Slika, opt => opt.Ignore()); // Ako ne želite da mapirate određeno polje, koristite Ignore

        // Opcionalno: Mapiranje između List modela i ListDTO ako imate takav DTO
        // CreateMap<List, ListDTO>();
    }
}
