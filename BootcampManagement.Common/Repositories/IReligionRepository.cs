using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IReligionRepository
    {
        List<Religion> Get();
        Religion Get(int? id);
        bool Insert(ReligionParam religionParam);
        bool Update(int? id, ReligionParam religionParam);
        bool Delete(int? id);
    }
}
