using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface IBatchRepository
    {
        List<Batch> Get();
        Batch Get(int? id);
        bool Insert(BatchParam batchParam);
        bool Update(int? id, BatchParam batchParam);
        bool Delete(int? id);
    }
}
