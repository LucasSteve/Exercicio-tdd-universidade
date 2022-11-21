using AutoMapper;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;

namespace Exercicio09.Api.Profiles
{
    public class MappingProfile : Profile
    {
       public MappingProfile() 
        {
            #region Entity to Request

            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<EnderecoRequest, Endereco>();           
            CreateMap<DepartamentoRequest, Departamento>();
            CreateMap<CursoRequest, Curso>();
            CreateMap<PerfilRequest, Perfil>();
            CreateMap<PerfilNomeRequest, Perfil>();
            CreateMap<UsuarioCpfRequest, Usuario>();
            CreateMap<DepartamentoNomeRequest,Departamento>();
            CreateMap<CursoTurnoRequest, Curso>();

            #endregion

            #region Response to Entity

            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<Endereco, EnderecoResponse>();            
            CreateMap<Departamento, DepartamentoResponse>();
            CreateMap<Curso, CursoResponse>();
            CreateMap<Perfil, PerfilResponse>();
            CreateMap<ApiCep, EnderecoApiResponse>()
                .ForMember(obj => obj.Cep, map => map.MapFrom(src => src.Cep))
                .ForMember(obj => obj.Cidade, map => map.MapFrom(src => src.City))
                .ForMember(obj => obj.Estado, map => map.MapFrom(src => src.State))
                .ForMember(obj => obj.Rua, map => map.MapFrom(src => src.Street))
                .ForMember(obj => obj.Bairro, map => map.MapFrom(src => src.Neighborhood));
            #endregion
        }

    }
}
