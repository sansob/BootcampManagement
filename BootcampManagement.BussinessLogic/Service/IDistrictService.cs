using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface IDistrictService
    {
        List<District> Get();
        District Get(int? id);
        bool Insert(DistrictParam districtParam);
        bool Update(int? id, DistrictParam districtParam);
        bool Delete(int? id);
    }
}
