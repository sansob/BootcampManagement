using BootcampManagement.Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BootcampManagement.Client.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Lessons
        public ActionResult Index()
        {
            return View(LoadLesson());
        }

        public JsonResult LoadLesson()
        {
            IEnumerable<LessonVM> lessonVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Lessons");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LessonVM>>();
                readTask.Wait();
                lessonVM = readTask.Result;
            }
            else
            {
                lessonVM = Enumerable.Empty<LessonVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(lessonVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LessonVM lessonVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(lessonVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (lessonVM.Id.Equals(0))
            {
                var result = client.PostAsync("Lessons", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Lessons/" + lessonVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LessonVM lessonVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Lessons/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LessonVM>();
                readTask.Wait();
                lessonVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(lessonVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Lessons/" + id).Result;
        }
    }
}