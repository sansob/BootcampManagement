﻿using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> Get();
        Company Get(int? id);
        bool Insert(CompanyParam companyParam);
        bool Update(int? id, CompanyParam companyParam);
        bool Delete(int? id);
    }
}
