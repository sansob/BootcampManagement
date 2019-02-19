using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(int? id);
        bool Insert(StudentParam studentParam);
        bool Update(int? id, StudentParam studentParam);
        bool Delete(int? id);
    }
}
