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
    public class BatchesController : ApiController
    {
        private readonly IBatchService _batchService;

        public BatchesController() { }

        public BatchesController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        // GET: api/Batchs
        public IEnumerable<Batch> Get()
        {
            return _batchService.Get();
        }

        // GET: api/Batchs/5
        public Batch Get(int id)
        {
            return _batchService.Get(id);
        }

        // POST: api/Batchs
        public void Post(BatchParam batchParam)
        {
            _batchService.Insert(batchParam);
        }

        // PUT: api/Batchs/5
        public void Put(int id, BatchParam batchParam)
        {
            _batchService.Update(id, batchParam);
        }

        // DELETE: api/Batchs/5
        public void Delete(int id)
        {
            _batchService.Delete(id);
        }
    }
}
