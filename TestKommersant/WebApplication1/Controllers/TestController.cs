using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestDataService testDataService;

        public TestController(ITestDataService testDataService)
        {
            this.testDataService = testDataService;
        }

        [HttpGet]
        public ViewResult Index(string flt)
        {
            var model = testDataService.GetRepo();

            return View(model);
        }

        public ActionResult Fill()
        {
            testDataService.FillRepo();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(List<TestData> model)
        {
            testDataService.ClearRepo(model.ToList());

            return RedirectToAction("Index");
        }
    }
}