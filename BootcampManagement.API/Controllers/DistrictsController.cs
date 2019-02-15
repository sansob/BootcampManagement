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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DistrictsController : ApiController
    {
        private readonly IDistrictService _districtService;

        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GET: api/Districts
        public IEnumerable<District> Get()
        {
            return _districtService.Get();
        }

        // GET: api/Districts/5
        public District Get(int id)
        {
            return _districtService.Get(id);
        }

        // POST: api/Districts
        public void Post(DistrictParam districtParam)
        {
            _districtService.Insert(districtParam);
        }

        // PUT: api/Districts/5
        public void Put(int id, DistrictParam districtParam)
        {
            _districtService.Update(id, districtParam);
        }

        // DELETE: api/Districts/5
        public void Delete(int id)
        {
            _districtService.Delete(id);
        }
    }
}
