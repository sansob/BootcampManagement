using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface IRegencyService
    {
        List<Regency> Get();
        Regency Get(int? id);
        bool Insert(RegencyParam regencyParam);
        bool Update(int? id, RegencyParam regencyParam);
        bool Delete(int? id);
    }
}
