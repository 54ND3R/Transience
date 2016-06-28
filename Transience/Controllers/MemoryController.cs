using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transience.Models;
using Transience.Models.DAL.Interfaces;
using Transience.Models.DAL.Repositories;

namespace Transience.Controllers
{
    public class MemoryController : Controller
    {
        private IMemoryRepository rep;

        //CTOR
        public MemoryController() {
            rep = new MemoryRepository(new TransienceDbContext);
        }
        public MemoryController(IMemoryRepository rep) {
            this.rep = rep;
        }

        //Overview
        public ActionResult Overview()
        {
            var mems = rep.Get();
            return View(mems);
        }

        public ActionResult New() {
            Memory newMemory = new Memory();
            return View(newMemory);
        }

        protected override void Dispose(bool disposing) {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}