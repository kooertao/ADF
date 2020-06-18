using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Contract.Response
{
    public class MemberViewModel
    {
        public string Name { get; set; }
        public string MemberGen { get; set; }
        public bool IsEmployed { get; set; }
        public int Age { get; set; }
        public string FamilyName { get; set; }
    }
}
