using ADF.Core.Model.Contract.Response;
using ADF.Core.Model.Entities;
using AutoMapper;

namespace ADF.App.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Member, MemberViewModel>()
                .ForMember(d => d.MemberGen, opt => opt.MapFrom(s => s.MemberGen.ToString()));
        }
    }
}
