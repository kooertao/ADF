using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Contract.Request
{
    public class CreateMemberRequest
    {
        public bool IsEmployed { get; set; }
        public string MemberGen { get; set; }
        public int Age { get; set; }
        public string FamilyName { get; set; }
    }
}
