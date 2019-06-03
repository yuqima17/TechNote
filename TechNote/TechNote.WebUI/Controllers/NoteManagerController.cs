using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechNote.Core;
using TechNote.DataAccess;
using TechNote.DataAccess.InMemory;

namespace TechNote.WebUI.Controllers
{
    public class NoteManagerController : Controller
    {
        NoteRepository noteContext;
        public NoteManagerController()
        {
            noteContext = new NoteRepository();
        }
        // GET: NoteManager
        public ActionResult Index()
        {
            List<Note> notes = noteContext.Collections().ToList();
            return View(notes);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note n)
        {
            if (!ModelState.IsValid)
            {
                return View(n);
            }
            else
            {
                noteContext.Insert(n);
                noteContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string id)
        {
            Note noteDetails = noteContext.Find(id);
            if (noteDetails == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(noteDetails);
            }
            
        }

        public ActionResult Edit(string id)
        {
            Note noteToEdit = noteContext.Find(id);
            if (noteToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(noteToEdit);
            }
                
        }

        [HttpPost]
        public ActionResult Edit(Note n,String id)
        {
            Note noteToEdit = noteContext.Find(n.Id);
            if (noteToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(noteToEdit);
                }
                else
                { 
                    noteContext.Update(n);
                    noteContext.Commit();
                    return RedirectToAction("Details",new { id=n.Id});
                }
                
            }

        }

        public ActionResult Delete(string id)
        {
            Note noteToDelete = noteContext.Find(id);
            if (noteToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(noteToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Note noteToDelete = noteContext.Find(id);
            if (noteToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                noteContext.Delete(id);
                noteContext.Commit();
                return RedirectToAction("Index");
            }

        }


    }
}