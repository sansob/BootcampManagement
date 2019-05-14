using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class CompanyRepository : ICompanyRepository
    {
        static MyContext myContext = new MyContext();
        Company company = new Company();

        bool status = false;

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            get.IsDelete = true;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Company> Get()
        {
            var get = myContext.Companies.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Company Get(int? id)
        {
            var get = myContext.Companies.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(CompanyParam companyParam)
        {
            company.Name = companyParam.Name;
            company.Address = companyParam.Address;
            var getVillage = myContext.Villages.Find(companyParam.Village_Id);
            company.Village = getVillage;
            company.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Companies.Add(company);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, CompanyParam companyParam)
        {
            var get = Get(id);
            get.Name = companyParam.Name;
            get.Address = companyParam.Address;
            var getVillage = myContext.Villages.Find(companyParam.Village_Id);
            get.Village = getVillage;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
