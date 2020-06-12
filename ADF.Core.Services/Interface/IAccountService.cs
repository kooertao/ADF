using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Services
{
    public interface IAccountService : IBaseServices<Family>
    {
        void CreateFamily(Family family);   
    }
}
