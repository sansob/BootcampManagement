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
    public class RegencyService : IRegencyService
    {
        bool status = false;

        private readonly IRegencyRepository _regencyRepository;

        public RegencyService(IRegencyRepository regencyRepository)
        {
            _regencyRepository = regencyRepository;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _regencyRepository.Delete(get.Id);
        }

        public List<Regency> Get()
        {
            var get = _regencyRepository.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Regency Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _regencyRepository.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            if (regencyParam == null)
            {
                throw new NullReferenceException();
            }
            else if (regencyParam.Name == " " || regencyParam.Province_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _regencyRepository.Insert(regencyParam);
            }
            return status;
        }

        public bool Update(int? id, RegencyParam regencyParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (regencyParam == null)
            {
                throw new NullReferenceException();
            }
            else if (regencyParam.Name == " " || regencyParam.Province_Id.ToString() == " ")
            {
                status = false;
            }
            else
            {
                status = _regencyRepository.Update(id, regencyParam);
            }
            return status;
        }
    }
}
