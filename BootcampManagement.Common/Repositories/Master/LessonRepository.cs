using BootcampManagement.Data;
using BootcampManagement.Data.Model;
using BootcampManagement.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.Common.Repositories.Master
{
    public class LessonRepository : ILessonRepository
    {
        static MyContext myContext = new MyContext();
        Lesson lesson = new Lesson();
        SaveChange saveChange = new SaveChange(myContext);

        public bool Delete(int? id)
        {
            var delete = Get(id);
            delete.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            delete.IsDelete = true;
            return saveChange.save();
        }

        public List<Lesson> Get()
        {
            var get = myContext.Lessons.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Lesson Get(int? id)
        {
            var get = myContext.Lessons.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(LessonParam lessonParam)
        {
            lesson.Name = lessonParam.Name;
            lesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Lessons.Add(lesson);
            return saveChange.save();
        }

        public bool Update(int? id, LessonParam lessonParam)
        {
            var put = Get(id);
            put.Name = lessonParam.Name;
            put.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            return saveChange.save();
        }
    }
}
