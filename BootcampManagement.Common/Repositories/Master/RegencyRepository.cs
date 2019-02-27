using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class RegencyRepository : IRegencyRepository
    {
        static MyContext myContext = new MyContext();
        Regency regency = new Regency();
        SaveChange saveChange = new SaveChange(myContext);

        bool status = false;

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            get.IsDelete = true;
            return saveChange.save();
        }

        public List<Regency> Get()
        {
            var get = myContext.Regencies.Include("Province").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Regency Get(int? id)
        {
            var get = myContext.Regencies.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            regency.Name = regencyParam.Name;
            var getProvince = myContext.Provinces.Find(regencyParam.Province_Id);
            regency.Province = getProvince;
            regency.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Regencies.Add(regency);
            return saveChange.save();
        }

        public bool Update(int? id, RegencyParam regencyParam)
        {
            var get = Get(id);
            get.Name = regencyParam.Name;
            var getProvince = myContext.Provinces.Find(regencyParam.Province_Id);
            get.Province = getProvince;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
