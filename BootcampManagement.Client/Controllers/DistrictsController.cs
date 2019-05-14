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
    public class DistrictsController : Controller
    {
        // GET: Districts
        public ActionResult Index()
        {
            return View(LoadDistricts());
        }

        public JsonResult LoadDistricts()
        {
            IEnumerable<DistrictVM> districtVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var responseTask = client.GetAsync("Districts");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<DistrictVM>>();
                readTask.Wait();
                districtVM = readTask.Result;
            }
            else
            {
                districtVM = Enumerable.Empty<DistrictVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(districtVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(DistrictVM districtVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var myContent = JsonConvert.SerializeObject(districtVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (districtVM.Id.Equals(0))
            {
                var result = client.PostAsync("Districts", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Districts/" + districtVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            RegencyVM regencyVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var responseTask = client.GetAsync("Districts/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<RegencyVM>();
                readTask.Wait();
                regencyVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(regencyVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12280/api/");
            var result = client.DeleteAsync("Districts/" + id).Result;
        }
    }
}