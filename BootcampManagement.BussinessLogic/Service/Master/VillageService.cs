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
    public class VillageService : IVillageService
    {
        bool status = false;

        private readonly IVillageRepository _villageRepository;

        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _villageRepository.Delete(get.Id);
        }

        public List<Village> Get()
        {
            var get = _villageRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Village Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _villageRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(VillageParam villageParam)
        {
            if (villageParam == null)
            {
                throw new NullReferenceException();
            }
            else if (villageParam.Name == " " || villageParam.District_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _villageRepository.Insert(villageParam);
            }
            return status;
        }

        public bool Update(int? id, VillageParam villageParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (villageParam == null)
            {
                throw new NullReferenceException();
            }
            else if (villageParam.Name == " " || villageParam.District_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _villageRepository.Update(id, villageParam);
            }
            return status;
        }
    }
}
