using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechNote.Core.Contracts;
using TechNote.Core.Models;
using TechNote.DataAccess.InMemory;

namespace TechNote.WebUI.Controllers
{
    public class CodingLanguageManagerController : Controller
    {
        IRepository<CodingLanguage> context;
        public CodingLanguageManagerController(IRepository<CodingLanguage> context)
        {
            this.context = context;
        }
       
        // GET: CodingLanguageManager
        public ActionResult Index()
        {
                List<CodingLanguage> codingLanguages = context.Collections().ToList();
                return View(codingLanguages);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CodingLanguage n)
        {

            
                context.Insert(n);
                context.Commit();
                return RedirectToAction("Index");
            
        }

        public ActionResult Edit(string id)
        {
            CodingLanguage cToEdit = context.Find(id);
            if (cToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(cToEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(CodingLanguage n, String id)
        {
            CodingLanguage cToEdit = context.Find(n.Id);
            if (cToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                    cToEdit.Name=n.Name;
                    context.Commit();
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            CodingLanguage cToDelete = context.Find(id);
            if (cToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(cToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            CodingLanguage cToDelete = context.Find(id);
            if (cToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}