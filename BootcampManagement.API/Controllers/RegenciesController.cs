using BootcampManagement.BussinessLogic.Service;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace BootcampManagement.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegenciesController : ApiController
    {
        private readonly IRegencyService _regencyService;

        public RegenciesController() { }

        public RegenciesController(IRegencyService regencyService)
        {
            _regencyService = regencyService;
        }

        // GET: api/Lesson/5
        public Regency Get(int id)
        {
            return _regencyService.Get(id);
        }

        // GET: api/Regencies
        public IEnumerable<Regency> Get()
        {
            return _regencyService.Get();
        }

        // POST: api/Lesson
        public void Post(RegencyParam regencyParam)
        {
            _regencyService.Insert(regencyParam);
        }

        // PUT: api/Lesson/5
        public void Put(int id, RegencyParam regencyParam)
        {
            _regencyService.Update(id, regencyParam);
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
            _regencyService.Delete(id);
        }
    }
}
