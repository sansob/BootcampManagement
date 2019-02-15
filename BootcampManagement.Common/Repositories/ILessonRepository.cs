using BootcampManagement.Data.Model;
using BootcampManagement.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories
{
    public interface ILessonRepository
    {
        List<Lesson> Get();
        Lesson Get(int? id);
        bool Insert(LessonParam lessonParam);
        bool Update(int? id, LessonParam lessonParam);
        bool Delete(int? id);
    }
}
