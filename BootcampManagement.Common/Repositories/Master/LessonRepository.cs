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
        private bool status = false;
        MyContext myContext = new MyContext();
        Lesson lesson = new Lesson();

        public bool Delete(int? id)
        {
            var delete = Get(id);
            delete.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            delete.IsDelete = true;
            var result = myContext.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Lesson> Get()
        {
            return myContext.Lessons.Where(x => x.IsDelete == false).ToList();
        }

        public Lesson Get(int? id)
        {
            return myContext.Lessons.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
        }

        public bool Insert(LessonParam lessonParam)
        {
            lesson.Name = lessonParam.Name;
            lesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Lessons.Add(lesson);
            var result = myContext.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? id, LessonParam lessonParam)
        {
            var put = Get(id);
            put.Name = lessonParam.Name;
            put.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
