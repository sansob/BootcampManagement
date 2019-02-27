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
    public class ProvinceRepository : IProvinceRepository
    {
        static MyContext myContext = new MyContext();
        Province province = new Province();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.IsDelete = true;
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<Province> Get()
        {
            return myContext.Provinces.Where(x => x.IsDelete == false).ToList();
        }

        public Province Get(int? id)
        {
            var get = myContext.Provinces.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(ProvinceParam provinceParam)
        {
            province.Name = provinceParam.Name;
            province.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Provinces.Add(province);
            return saveChange.save();
        }

        public bool Update(int? id, ProvinceParam provinceParam)
        {
            var get = Get(id);
            get.Name = provinceParam.Name;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
