using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class RegencyRepository : IRegencyRepository
    {
        MyContext _context = new MyContext();
        Regency regency = new Regency();

        bool status = false;

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            get.IsDelete = true;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Regency> Get()
        {
            var get = _context.Regencies.Include("Province").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Regency Get(int? id)
        {
            var get = _context.Regencies.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            regency.Name = regencyParam.Name;
            var getProvince = _context.Provinces.Find(regencyParam.Province_Id);
            regency.Province = getProvince;
            regency.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Regencies.Add(regency);
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, RegencyParam regencyParam)
        {
            var get = Get(id);
            get.Name = regencyParam.Name;
            var getProvince = _context.Provinces.Find(regencyParam.Province_Id);
            get.Province = getProvince;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
