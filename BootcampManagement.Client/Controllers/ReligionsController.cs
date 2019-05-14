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
    public class ReligionsController : Controller
    {
        // GET: Religions
        public ActionResult Index()
        {
            return View(LoadReligions());
        }

        public JsonResult LoadReligions()
        {
            IEnumerable<ReligionVM> religionVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Religions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ReligionVM>>();
                readTask.Wait();
                religionVM = readTask.Result;
            }
            else
            {
                religionVM = Enumerable.Empty<ReligionVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(religionVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ReligionVM religionVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(religionVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (religionVM.Id.Equals(0))
            {
                var result = client.PostAsync("Religions", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Religions/" + religionVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ReligionVM religionVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Religions/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ReligionVM>();
                readTask.Wait();
                religionVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(religionVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Religions/" + id).Result;
        }
    }
}