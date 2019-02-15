using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface IVillageService
    {
        List<Village> Get();
        Village Get(int? id);
        bool Insert(VillageParam villageParam);
        bool Update(int? id, VillageParam villageParam);
        bool Delete(int? id);
    }
}
