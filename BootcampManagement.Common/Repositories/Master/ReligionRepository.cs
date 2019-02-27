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
    public class ReligionRepository : IReligionRepository
    {
        static MyContext myContext = new MyContext();
        Religion religion = new Religion();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            get.IsDelete = true;
            return saveChange.save();
        }

        public List<Religion> Get()
        {
            return myContext.Religions.Where(x => x.IsDelete == false).ToList();
        }

        public Religion Get(int? id)
        {
            return myContext.Religions.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
        }

        public bool Insert(ReligionParam religionParam)
        {
            religion.Name = religionParam.Name;
            religion.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Religions.Add(religion);
            return saveChange.save();
        }

        public bool Update(int? id, ReligionParam religionParam)
        {
            var get = Get(id);
            get.Name = religionParam.Name;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
