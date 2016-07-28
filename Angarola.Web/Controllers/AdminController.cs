using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angarola.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [Route("brands")]
        public ActionResult Brands()
        {
            return View();
        }

        [Route("calendar")]
        public ActionResult Calendar()
        {
            return View();
        }
    }
}   