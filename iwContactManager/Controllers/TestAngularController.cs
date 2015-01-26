using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iwContactManager.Controllers
{
    [AllowAnonymous]
    public class TestAngularController : Controller
    {
        // GET: TestAngular
        public ActionResult Winners()
        {
            return View();
        }
    }
}