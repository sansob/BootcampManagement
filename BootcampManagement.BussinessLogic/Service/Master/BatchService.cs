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
    public class BatchService : IBatchService
    {
        bool status = false;

        private readonly IBatchRepository _batchRepository;

        public BatchService(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public BatchService() { }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _batchRepository.Delete(get.Id);
        }

        public List<Batch> Get()
        {
            var get = _batchRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Batch Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _batchRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(BatchParam batchParam)
        {
            if (batchParam == null)
            {
                throw new NullReferenceException();
            }
            else if (batchParam.StartDate == " " || batchParam.EndDate == " ")
            {
                status = false;
            }
            else
            {
                status = _batchRepository.Insert(batchParam);
            }
            return status;
        }

        public bool Update(int? id, BatchParam batchParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (batchParam == null)
            {
                throw new NullReferenceException();
            }
            else if (batchParam.StartDate == " " || batchParam.EndDate == " ")
            {
                status = false;
            }
            else
            {
                status = _batchRepository.Update(id, batchParam);
            }
            return status;
        }
    }
}
