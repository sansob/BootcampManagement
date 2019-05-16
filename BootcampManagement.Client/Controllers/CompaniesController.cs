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
    public class CompaniesController : Controller
    {
        // GET: Companies
        public ActionResult Index()
        {
            return View(LoadCompany());
        }

        public JsonResult LoadCompany()
        {
            IEnumerable<CompanyVM> companyVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Companies");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<CompanyVM>>();
                readTask.Wait();
                companyVM = readTask.Result;
            }
            else
            {
                companyVM = Enumerable.Empty<CompanyVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(companyVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(CompanyVM companyVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(companyVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (companyVM.Id.Equals(0))
            {
                var result = client.PostAsync("Companies", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Companies/" + companyVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            CompanyVM companyVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Companies/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CompanyVM>();
                readTask.Wait();
                companyVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(companyVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Companies/" + id).Result;
        }
    }
}