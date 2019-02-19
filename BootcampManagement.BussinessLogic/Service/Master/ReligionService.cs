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
    public class ReligionService : IReligionService
    {
        bool status = false;

        private readonly IReligionRepository _religionRepository;

        public ReligionService(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _religionRepository.Delete(get.Id);
        }

        public List<Religion> Get()
        {
            var get = _religionRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Religion Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _religionRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(ReligionParam religionParam)
        {
            if (religionParam == null)
            {
                throw new NullReferenceException();
            }
            else if (religionParam.Name == " ")
            {
                status = false;
            }
            else
            {
                status = _religionRepository.Insert(religionParam);
            }
            return status;
        }

        public bool Update(int? id, ReligionParam religionParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (religionParam == null)
            {
                throw new NullReferenceException();
            }
            else if (religionParam.Name == " ")
            {
                status = false;
            }
            else
            {
                status = _religionRepository.Update(id, religionParam);
            }
            return status;
        }
    }
}
