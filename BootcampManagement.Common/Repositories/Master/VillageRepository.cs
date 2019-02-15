using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.Common.Repositories.Master
{
    public class VillageRepository : IVillageRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Village village = new Village();

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.IsDelete = true;
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Village> Get()
        {
            return myContext.Villages.Where(x => x.IsDelete == false).ToList();
        }

        public Village Get(int? id)
        {
            return myContext.Villages.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
        }

        public bool Insert(VillageParam villageParam)
        {
            village.Name = villageParam.Name;
            var getDistrict = myContext.Districts.Find(villageParam.District_Id);
            village.District = getDistrict;
            village.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Villages.Add(village);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, VillageParam villageParam)
        {
            var get = Get(id);
            get.Name = villageParam.Name;
            var getDistrict = myContext.Districts.Find(villageParam.District_Id);
            get.District = getDistrict;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
