using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class ProvinceRepository : IProvinceRepository
    {
        private bool status = false;
        MyContext _context = new MyContext();
        Province province = new Province();

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.IsDelete = true;
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Province> Get()
        {
            return _context.Provinces.Where(x => x.IsDelete == false).ToList();
        }

        public Province Get(int? id)
        {
            var get = _context.Provinces.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(ProvinceParam provinceParam)
        {
            province.Name = provinceParam.Name;
            province.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Provinces.Add(province);
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, ProvinceParam provinceParam)
        {
            var get = Get(id);
            get.Name = provinceParam.Name;
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
