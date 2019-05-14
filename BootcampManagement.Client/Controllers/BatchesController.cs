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
    public class BatchesController : Controller
    {
        // GET: Batches
        public ActionResult Index()
        {
            return View(LoadBatch());
        }

        public JsonResult LoadBatch()
        {
            IEnumerable<BatchVM> batchVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Batches");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<BatchVM>>();
                readTask.Wait();
                batchVM = readTask.Result;
            }
            else
            {
                batchVM = Enumerable.Empty<BatchVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(batchVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(BatchVM batchVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(batchVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (batchVM.Id.Equals(0))
            {
                var result = client.PostAsync("Batches", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Batches/" + batchVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ProvinceVM provinceVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Batches/" + id);
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
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Batches/" + id).Result;
        }
    }
}