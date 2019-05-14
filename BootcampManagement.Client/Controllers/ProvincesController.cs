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
    public class ProvincesController : Controller
    {
        // GET: Provinces
        public ActionResult Index()
        {
            return View(LoadProvince());
        }

        public JsonResult LoadProvince()
        {
            IEnumerable<ProvinceVM> provinceVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var responseTask = client.GetAsync("Provinces");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ProvinceVM>>();
                readTask.Wait();
                provinceVM = readTask.Result;
            }
            else
            {
                provinceVM = Enumerable.Empty<ProvinceVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(provinceVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ProvinceVM provinceVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var myContent = JsonConvert.SerializeObject(provinceVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (provinceVM.Id.Equals(0))
            {
                var result = client.PostAsync("Provinces", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Provinces/" + provinceVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ProvinceVM provinceVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var responseTask = client.GetAsync("Provinces/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ProvinceVM>();
                readTask.Wait();
                provinceVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(provinceVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var result = client.DeleteAsync("Provinces/" + id).Result;
        }
    }
}