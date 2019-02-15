using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IVillageRepository
    {
        List<Village> Get();
        Village Get(int? id);
        bool Insert(VillageParam villageParam);
        bool Update(int? id, VillageParam villageParam);
        bool Delete(int? id);
    }
}
