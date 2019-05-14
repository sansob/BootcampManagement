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
    public class ReligionsController : ApiController
    {
        private readonly IReligionService _religionService;

        public ReligionsController() { }

        public ReligionsController(IReligionService religionService)
        {
            _religionService = religionService;
        }

        // GET: api/Lesson/5
        public Religion Get(int id)
        {
            return _religionService.Get(id);
        }

        // POST: api/Lesson
        public void Post(ReligionParam religionParam)
        {
            _religionService.Insert(religionParam);
        }

        // PUT: api/Lesson/5
        public void Put(int id, ReligionParam religionParam)
        {
            _religionService.Update(id, religionParam);
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
            _religionService.Delete(id);
        }

        // GET: api/Regencies
        public IEnumerable<Religion> Get()
        {
            return _religionService.Get();
        }
    }
}
