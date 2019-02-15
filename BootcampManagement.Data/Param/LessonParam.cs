using BootcampManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampManagement.DataAccess.Param
{
    public class LessonParam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LessonParam() { }

        public LessonParam(Lesson lesson)
        {
            lesson.Name = this.Name;
            lesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(Lesson lesson)
        {
            lesson.Id = this.Id;
            lesson.Name = this.Name;
            lesson.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete(Lesson lesson)
        {
            lesson.IsDelete = true;
            lesson.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
