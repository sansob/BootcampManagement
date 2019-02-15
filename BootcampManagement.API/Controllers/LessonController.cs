using BootcampManagement.BussinessLogic.Service;
using BootcampManagement.Data.Model;
using BootcampManagement.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace BootcampManagement.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LessonController : ApiController
    {
        private readonly ILessonService _lessonService;

        public LessonController() { }

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        // GET: api/Lesson/5
        public Lesson Get(int id)
        {
            return _lessonService.Get(id);
        }

        // POST: api/Lesson
        public void Post(LessonParam lessonParam)
        {
            _lessonService.Insert(lessonParam);
        }

        // PUT: api/Lesson/5
        public void Put(int id, LessonParam lessonParam)
        {
            _lessonService.Update(id, lessonParam);
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
            _lessonService.Delete(id);
        }

        public JsonResult<IEnumerable<Lesson>> Get()
        {
            IEnumerable<Lesson> getSupplier = _lessonService.Get().Select(x => new Lesson
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray();
            return Json(getSupplier);
        }
    }
}
