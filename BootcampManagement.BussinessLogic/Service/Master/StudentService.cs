using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampManagement.Data.Model;
using BootcampManagement.Data.Param;

namespace BootcampManagement.BussinessLogic.Service.Master
{
    public class StudentService : IStudentService
    {
        bool status = false;

        private readonly IStudentService _studentService;

        public StudentService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public bool Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _studentService.Delete(get.Id);
        }

        public List<Student> Get()
        {
            var get = _studentService.Get();
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Student Get(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = _studentService.Get(id);
            if (get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(StudentParam studentParam)
        {
            if (studentParam == null)
            {
                throw new NullReferenceException();
            }
            else if (studentParam.FirstName == " " || studentParam.LastName == " ")
            {
                status = false;
            }
            else
            {
                status = _studentService.Insert(studentParam);
            }
            return status;
        }

        public bool Update(int? id, StudentParam studentParam)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if (studentParam == null)
            {
                throw new NullReferenceException();
            }
            else if (studentParam.FirstName == " " || studentParam.LastName == " ")
            {
                status = false;
            }
            else
            {
                status = _studentService.Update(id, studentParam);
            }
            return status;
        }
    }
}
