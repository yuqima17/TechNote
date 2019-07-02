using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechNote.Core.Contracts;
using TechNote.Core.Models;

namespace TechNote.WebUI.Controllers
{
    public class NoteTypeController : Controller
    {
        IRepository<NoteType> typeContext;
        // GET: NoteType
        public NoteTypeController(IRepository<NoteType> typeContext1)
        {
            typeContext = typeContext1;
        }
        public ActionResult Index()
        {
            List<NoteType> noteTypes = typeContext.Collections().ToList();

            return View(noteTypes);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(NoteType type)
        {
            typeContext.Insert(type);
            typeContext.Commit();
            return RedirectToAction("Index");
        }

    }
}