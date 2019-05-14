using BootcampManagement.BussinessLogic.Service;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BootcampManagement.API.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Companies
        public IEnumerable<Company> Get()
        {
            return _companyService.Get();
        }

        // GET: api/Companies/5
        public Company Get(int id)
        {
            return _companyService.Get(id);
        }

        // POST: api/Companies
        public void Post(CompanyParam companyParam)
        {
            _companyService.Insert(companyParam);
        }

        // PUT: api/Companies/5
        public void Put(int id, CompanyParam companyParam)
        {
            _companyService.Update(id, companyParam);
        }

        // DELETE: api/Companies/5
        public void Delete(int id)
        {
            _companyService.Delete(id);
        }
    }
}
