using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Common.Repositories;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.BussinessLogic.Service.Master
{
    public class CompanyService : ICompanyService
    {
        bool status = false;

        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _companyRepository.Delete(get.Id);
        }

        public List<Company> Get()
        {
            var get = _companyRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Company Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _companyRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(CompanyParam companyParam)
        {
            if (companyParam == null)
            {
                throw new NullReferenceException();
            }
            else if (companyParam.Name == " " || companyParam.Address == " " || companyParam.Village_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _companyRepository.Insert(companyParam);
            }
            return status;
        }

        public bool Update(int? id, CompanyParam companyParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (companyParam == null)
            {
                throw new NullReferenceException();
            }
            else if (companyParam.Name == " " || companyParam.Address == " " || companyParam.Village_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _companyRepository.Update(id, companyParam);
            }
            return status;
        }
    }
}
