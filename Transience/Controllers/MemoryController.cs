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
            rep = new MemoryRepository(new TransienceDbContext());
        }
        public MemoryController(IMemoryRepository rep) {
            this.rep = rep;
        }

        public ActionResult Overview()
        {
            var mems = rep.Get();
            return View(mems);
        }
        //New
        public ActionResult New() {
            Memory newMemory = new Memory();
            return View(newMemory);
        }

        public ActionResult Add(Memory newMemory) {
            if (ModelState.IsValid) {
                rep.Insert(newMemory);
                rep.Save();
            }
            return RedirectToAction("Overview");
        }
        //Update
        public ActionResult Change(int? id) {
            if (id.HasValue) {
                Memory changeMemory = rep.GetById(id.Value);
                return View(changeMemory);
            }
            return RedirectToAction("Overview");
        }

        public ActionResult Update(Memory updatedMemory) {
            if (ModelState.IsValid) {
                rep.Update(updatedMemory);
                rep.Save();
            }
            return RedirectToAction("Overview");
        }
        //Delete
        public ActionResult RequestDelete(int? id) {
            if (id.HasValue) {
                Memory deleteMemory = rep.GetById(id.Value);
                return View(deleteMemory);
            }
            return View();
        }

        public ActionResult Delete(int? id) {
            if (id.HasValue) {
                rep.Delete(id.Value);
                rep.Save();
            }
            return RedirectToAction("Overview");
        }


        protected override void Dispose(bool disposing) {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}