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
    public class VillagesController : ApiController
    {
        private readonly IVillageService _villageService;

        public VillagesController(IVillageService villageService)
        {
            _villageService = villageService;
        }

        // GET: api/Villages
        public IEnumerable<Village> Get()
        {
            return _villageService.Get();
        }

        // GET: api/Villages/5
        public Village Get(int id)
        {
            return _villageService.Get(id);
        }

        // POST: api/Villages
        public void Post(VillageParam villageParam)
        {
            _villageService.Insert(villageParam);
        }

        // PUT: api/Villages/5
        public void Put(int id, VillageParam villageParam)
        {
            _villageService.Update(id, villageParam);
        }

        // DELETE: api/Villages/5
        public void Delete(int id)
        {
            _villageService.Delete(id);
        }
    }
}
