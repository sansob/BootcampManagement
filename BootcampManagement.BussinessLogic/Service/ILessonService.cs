using BootcampManagement.Data.Model;
using BootcampManagement.DataAccess.Param;
using System.Collections.Generic;

namespace BootcampManagement.BussinessLogic.Service
{
    public interface ILessonService
    {
        List<Lesson> Get();
        Lesson Get(int? id);
        bool Insert(LessonParam lessonParam);
        bool Update(int? id, LessonParam lessonParam);
        bool Delete(int? id);
    }
}
