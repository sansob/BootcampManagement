using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IProvinceRepository
    {
        List<Province> Get();
        Province Get(int? id);
        bool Insert(ProvinceParam provinceParam);
        bool Update(int? id, ProvinceParam provinceParam);
        bool Delete(int? id);
    }
}
