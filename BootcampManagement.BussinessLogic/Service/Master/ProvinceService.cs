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
    public class ProvinceService : IProvinceService
    {
        bool status = false;

        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _provinceRepository.Delete(get.Id);
        }

        public List<Province> Get()
        {
            var get = _provinceRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Province Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _provinceRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(ProvinceParam provinceParam)
        {
            if (provinceParam == null)
            {
                throw new NullReferenceException();
            }
            else if (provinceParam.Name == " ")
            {
                status = false;
            }
            else
            {
                status = _provinceRepository.Insert(provinceParam);
            }
            return status;
        }

        public bool Update(int? id, ProvinceParam provinceParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (provinceParam == null)
            {
                throw new NullReferenceException();
            }
            else if (provinceParam.Name == " ")
            {
                status = false;
            }
            else
            {
                status = _provinceRepository.Update(id, provinceParam);
            }
            return status;
        }
    }
}
