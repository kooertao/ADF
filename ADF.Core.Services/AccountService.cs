using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ADF.Core.Model.Entities;
using ADF.Core.Repository;

namespace ADF.Core.Services
{
    public class AccountService :IBaseServices<Member>, IAccountService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public IMemberRepository _MemberRepository;
        public IFamilyRepository _FamilyRepository;


        public AccountService(IUnitOfWork unitOfWork, IMemberRepository memberRepository, IFamilyRepository familyRepository)
        {
            _UnitOfWork = unitOfWork;
            _MemberRepository = memberRepository;
            _FamilyRepository = familyRepository;
        }

        public void CreateFamily(Family family)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateMember(Member member)
        {
            var currentTime = DateTime.Now;
            if(!string.IsNullOrWhiteSpace(member.FamilyName))
            {
                var family = _FamilyRepository.Get(f => f.Name == member.FamilyName);
                if(family.Result != null)
                {
                    _MemberRepository.Add(new Member
                    {
                        MemberGen = member.MemberGen,
                        Age = member.Age,
                        CreateTime = currentTime,
                        IsEmployed = member.IsEmployed,
                        FamilyId = family.Result.Id,
                        FamilyName = family.Result.Name,
                        LastUpdated = currentTime,
                        Name = member.Name
                    });
                }
                else
                {
                    var newFamily = new Family
                    {
                        Name = member.FamilyName,
                        CreateTime = currentTime,
                        LastUpdated = currentTime
                    };
                    //Create family
                    _FamilyRepository.Add(newFamily);

                    _MemberRepository.Add(new Member
                    {
                        MemberGen = member.MemberGen,
                        Age = member.Age,
                        CreateTime = currentTime,
                        IsEmployed = member.IsEmployed,
                        Family = newFamily,
                        FamilyName = newFamily.Name,
                        LastUpdated = currentTime,
                        Name = member.Name
                    });
                }
            }
            return await _UnitOfWork.SaveAsync();
        }
    }
}
