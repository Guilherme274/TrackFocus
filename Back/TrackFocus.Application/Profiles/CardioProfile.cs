using AutoMapper;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Profiles.Security
{
    public class CardioProfile : Profile
    {
        public CardioProfile()
        {
            CreateMap<CardioRequest, Cardio>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Exercicio, opt => opt.Ignore())
            .ForMember(dest => dest.ExercicioId, opt => opt.Ignore());            
            CreateMap<Cardio, CardioResponse>();
        }
    }
}