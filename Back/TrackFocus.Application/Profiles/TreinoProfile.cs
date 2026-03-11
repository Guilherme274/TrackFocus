using AutoMapper;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Profiles.Security
{
    public class TreinoProfile : Profile
    {
        public TreinoProfile()
        {
            CreateMap<TreinoRequest, Treino>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // Banco gera
            .ForMember(dest => dest.User, opt => opt.Ignore())  // Navegação
            .ForMember(dest => dest.UserId, opt => opt.Ignore());  // Vem do token

            CreateMap<Treino, TreinoResponse>();
            
        }
    }
}