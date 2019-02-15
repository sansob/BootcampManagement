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
    public class DistrictService : IDistrictService
    {
        bool status = false;

        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _districtRepository.Delete(get.Id);
        }

        public List<District> Get()
        {
            var get = _districtRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public District Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _districtRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(DistrictParam districtParam)
        {
            if (districtParam == null)
            {
                throw new NullReferenceException();
            }
            else if (districtParam.Name == " " || districtParam.Regency_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _districtRepository.Insert(districtParam);
            }
            return status;
        }

        public bool Update(int? id, DistrictParam districtParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (districtParam == null)
            {
                throw new NullReferenceException();
            }
            else if (districtParam.Name == " " || districtParam.Regency_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _districtRepository.Update(id, districtParam);
            }
            return status;
        }
    }
}
