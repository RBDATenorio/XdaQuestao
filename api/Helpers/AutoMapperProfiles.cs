using System.Linq;
using api.Domain;
using api.Dtos;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Questao, QuestaoDto>()
                        .ForMember(dest => dest.Cadernos,
                        opt => { opt.MapFrom(
                        src => src.CadernoQuestaos.Select(
                        x => x.Caderno).ToList());
                        });
            CreateMap<Aluno, AlunoDto>();
            CreateMap<Caderno, CadernoDto>()
                        .ForMember(dest => dest.Questaos, 
                        opt => { opt.MapFrom(src => src.CadernoQuestaos.Select(
                            x => x.Questao).ToList());
                        });
            CreateMap<Comentario, ComentarioDto>();

        }
    }
}