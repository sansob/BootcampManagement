using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class DistrictRepository : IDistrictRepository
    {
        private bool status = false;
        MyContext _context = new MyContext();
        District district = new District();

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<District> Get()
        {
            return _context.Districts.Where(x => x.IsDelete == false).ToList();
        }

        public District Get(int? id)
        {
            return _context.Districts.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public bool Insert(DistrictParam districtParam)
        {
            district.Name = districtParam.Name;
            var getRegency = _context.Regencies.Find(districtParam.Regency_Id);
            district.Regency = getRegency;
            district.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Districts.Add(district);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, DistrictParam districtParam)
        {
            var get = Get(id);
            get.Name = districtParam.Name;
            var getRegency = _context.Regencies.Find(districtParam.Regency_Id);
            get.Regency = getRegency;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
