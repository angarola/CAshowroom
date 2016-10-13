using System.Web.Mvc;
using Angarola.Web.Models;

namespace Angarola.Web.Controllers
{
    [RoutePrefix("Brands")]
    public class BrandsController : Controller
    {
        [Route, HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}"), HttpGet]
        public ActionResult Details(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }
    }
}