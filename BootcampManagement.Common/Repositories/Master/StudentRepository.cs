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
    public class StudentRepository : IStudentRepository
    {
        static MyContext myContext = new MyContext();
        Student student = new Student();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var get = Get(id);
            get.IsDelete = true;
            get.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }

        public List<Student> Get()
        {
            return myContext.Students.Where(x => x.IsDelete == false).ToList();
        }

        public Student Get(int? id)
        {
            return myContext.Students.SingleOrDefault(x => x.IsDelete == false);
        }

        public bool Insert(StudentParam studentParam)
        {
            student.Email = studentParam.Email;
            student.Username = studentParam.Username;
            student.Password = studentParam.Password;
            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.CreateDate = DateTimeOffset.Now.LocalDateTime;
            //var getVillage
            myContext.Students.Add(student);
            return saveChange.save();
        }

        public bool Update(int? id, StudentParam studentParam)
        {
            var get = Get(id);
            get.Email = studentParam.Email;
            get.Username = studentParam.Username;
            get.Password = studentParam.Password;
            get.FirstName = studentParam.FirstName;
            get.LastName = studentParam.LastName;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
