using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class DistrictRepository : IDistrictRepository
    {
        static MyContext myContext = new MyContext();
        District district = new District();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<District> Get()
        {
            return myContext.Districts.Where(x => x.IsDelete == false).ToList();
        }

        public District Get(int? id)
        {
            return myContext.Districts.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public bool Insert(DistrictParam districtParam)
        {
            district.Name = districtParam.Name;
            var getRegency = myContext.Regencies.Find(districtParam.Regency_Id);
            district.Regency = getRegency;
            district.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Districts.Add(district);
            return saveChange.save();
        }

        public bool Update(int? id, DistrictParam districtParam)
        {
            var get = Get(id);
            get.Name = districtParam.Name;
            var getRegency = myContext.Regencies.Find(districtParam.Regency_Id);
            get.Regency = getRegency;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
