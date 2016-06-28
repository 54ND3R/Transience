using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transience.Controllers
{
    public class MemoryController : Controller
    {
        // GET: Memory
        public ActionResult Overview()
        {
            return View();
        }
    }
}