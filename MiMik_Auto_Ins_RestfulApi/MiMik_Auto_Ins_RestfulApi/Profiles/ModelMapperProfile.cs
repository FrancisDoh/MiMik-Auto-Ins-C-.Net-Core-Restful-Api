using AutoMapper;
using MiMik_Auto_Ins_RestfulApi.Models.Domain;
using MiMik_Auto_Ins_RestfulApi.Models.DTOs;

namespace MiMik_Auto_Ins_RestfulApi.Profiles
{
    public class ModelMapperProfile : Profile
    {
        public ModelMapperProfile()
        {
            CreateMap<Models.Domain.Policy, Models.DTOs.Policy>(); // Dom.Pol => DTOs.Pol
            CreateMap<Models.DTOs.Policy, Models.Domain.Policy>(); // DTOs.Pol => Dom.Pol

            CreateMap<AddPolicyModel, Models.DTOs.Policy>(); //
        }
    }
}
