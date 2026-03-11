using AutoMapper;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Profiles.Security
{
    public class ExercicioProfile : Profile
    {
        public ExercicioProfile()
        {
            CreateMap<ExercicioRequest, Exercicio>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Treino, opt => opt.Ignore())
            .ForMember(dest => dest.TreinoId, opt => opt.Ignore())  // Será setado
            .ForMember(dest => dest.Tipo_Exercicio, opt => opt.Ignore());
            
            CreateMap<Exercicio, ExercicioResponse>();                        
        }
    }
}