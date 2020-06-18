using ADF.Core.Model.Contract.Request;
using ADF.Core.Model.Contract.Response;
using ADF.Core.Model.Entities;
using ADF.Core.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class AccountService :IBaseServices<Member>, IAccountService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public IMemberRepository _MemberRepository;
        public IFamilyRepository _FamilyRepository;
        public IMapper _Mapper;


        public AccountService(IUnitOfWork unitOfWork, IMemberRepository memberRepository, IFamilyRepository familyRepository, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _MemberRepository = memberRepository;
            _FamilyRepository = familyRepository;
            _Mapper = mapper;
        }

        public void CreateFamily(Family family)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MemberViewModel>> GetAllMembersAsync(string familyName)
        {
            var result = new List<MemberViewModel>();
            if(string.IsNullOrWhiteSpace(familyName))
            {
                return null;
            }

            var family = _FamilyRepository.Get(f => f.Name == familyName, true);
            if(family.Result != null && family.Result.Members.Count >0)
            {
                family.Result.Members.ForEach(m => {
                    result.Add(_Mapper.Map<MemberViewModel>(m));
                });                
            }
            return  result;
        }

        public async Task<bool> CreateMemberAsync(string name, CreateMemberRequest request)
        {
            var currentTime = DateTime.Now;           

            if (!string.IsNullOrWhiteSpace(request.FamilyName))
            {
                var family = _FamilyRepository.Get(f => f.Name == request.FamilyName);
                var member = new Member()
                {
                    Name = name,
                    CreateTime = currentTime,
                    LastUpdated = currentTime,
                    IsEmployed = request.IsEmployed,
                    FamilyName = request.FamilyName,
                    Age = request.Age,
                    MemberGen = request.MemberGen.Equals(Core.Model.Enum.Gender.Man.ToString(), StringComparison.OrdinalIgnoreCase) ?
                  Core.Model.Enum.Gender.Man : Core.Model.Enum.Gender.Female
                };

                if (family.Result != null)
                {  
                    member.Family = family.Result;
                    _MemberRepository.Add(member);
                }
                else
                {
                    var newFamily = new Family
                    {
                        Name = request.FamilyName,
                        CreateTime = currentTime,
                        LastUpdated = currentTime
                    };
                    //Create family
                    _FamilyRepository.Add(newFamily);
                    member.Family = newFamily;
                    _MemberRepository.Add(member);
                }
            }
            return await _UnitOfWork.SaveAsync();
        }
    }
}
