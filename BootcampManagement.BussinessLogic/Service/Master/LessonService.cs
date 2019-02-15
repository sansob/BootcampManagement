using BootcampManagement.Common.Repositories;
using BootcampManagement.Data.Model;
using BootcampManagement.DataAccess.Param;
using System;
using System.Collections.Generic;

namespace BootcampManagement.BussinessLogic.Service.Master
{
    public class LessonService : ILessonService
    {
        bool status = false;

        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public bool Delete(int? id)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            return _lessonRepository.Delete(get.Id);
        }

        public List<Lesson> Get()
        {
            var get = _lessonRepository.Get();
            if(get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public Lesson Get(int? id)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            var get = _lessonRepository.Get(id);
            if(get == null)
            {
                throw new NullReferenceException();
            }
            return get;
        }

        public bool Insert(LessonParam lessonParam)
        {
            if(lessonParam == null)
            {
                throw new NullReferenceException();
            } 
            else if (lessonParam.Name == " ")
            {
                status = false;
            }
            else
            {
                status = _lessonRepository.Insert(lessonParam);
            }
            return status;
        }

        public bool Update(int? id, LessonParam lessonParam)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }
            var get = Get(id);
            if(lessonParam == null)
            {
                throw new NullReferenceException();
            }
            else if(lessonParam.Name == " ")
            {
                status = false;
            }
            else 
            {
                status = _lessonRepository.Update(id, lessonParam);
            }
            return status;
        }
    }
}
