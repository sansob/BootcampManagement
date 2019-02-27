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
    public class BatchRepository : IBatchRepository
    {
        static MyContext myContext = new MyContext();
        Batch batch = new Batch();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.IsDelete = true;
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<Batch> Get()
        {
            return myContext.Batches.Where(x => x.IsDelete == false).ToList();
        }

        public Batch Get(int? id)
        {
            return myContext.Batches.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
        }

        public bool Insert(BatchParam batchParam)
        {
            batch.Name = batchParam.Name;
            batch.StartDate = Convert.ToDateTime(batchParam.StartDate);
            batch.EndDate = Convert.ToDateTime(batchParam.EndDate);
            batch.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Batches.Add(batch);
            return saveChange.save();
        }

        public bool Update(int? id, BatchParam batchParam)
        {
            var get = Get(id);
            get.StartDate = Convert.ToDateTime(batchParam.StartDate);
            get.EndDate = Convert.ToDateTime(batchParam.EndDate);
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
