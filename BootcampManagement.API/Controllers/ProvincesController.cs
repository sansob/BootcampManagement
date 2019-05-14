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
using System.Web.Http.Results;

namespace BootcampManagement.API.Controllers
{
    public class ProvincesController : ApiController
    {
        private readonly IProvinceService _provinceService;

        public ProvincesController() { }

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        // GET: api/Lesson/5
        public Province Get(int id)
        {
            return _provinceService.Get(id);
        }

        // POST: api/Lesson
        public void Post(ProvinceParam provinceParam)
        {
            _provinceService.Insert(provinceParam);
        }

        // PUT: api/Lesson/5
        public void Put(int id, ProvinceParam provinceParam)
        {
            _provinceService.Update(id, provinceParam);
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
            _provinceService.Delete(id);
        }

        public JsonResult<IEnumerable<Province>> Get()
        {
            IEnumerable<Province> getProvince = _provinceService.Get().Select(x => new Province
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray();
            return Json(getProvince);
        }
    }
}
