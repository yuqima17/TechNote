using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechNote.Core;
using TechNote.Core.Contracts;
using TechNote.Core.Models;
using TechNote.Core.ViewModels;

namespace TechNote.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Note> noteContext;
        IRepository<CodingLanguage> cContext;
        public HomeController(IRepository<Note> noteContext, IRepository<CodingLanguage> cContext)
        {
            this.noteContext = noteContext;
            this.cContext = cContext;
        }
        public ActionResult Index(string codingLanguage=null)
        {
            
            List<CodingLanguage> codingLanguages = cContext.Collections().ToList();
            List<Note> notes;
            if (codingLanguage == null)
            {
                notes = noteContext.Collections().ToList();
            }
            else
            {
                notes = noteContext.Collections().Where(n => n.CodingLanguage == codingLanguage).ToList();
            }
            NoteListViewModel viewModel = new NoteListViewModel();
            viewModel.notes = notes;
            viewModel.codingLanguages = codingLanguages;
            return View(viewModel);
        }

        public ActionResult Create()
        {
            NoteViewModel viewModel = new NoteViewModel();
            viewModel.note = new Note();
            viewModel.codingLanguages = cContext.Collections().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NoteViewModel n)
        {
            if (!ModelState.IsValid)
            {
                return View(n);
            }
            else
            {
                noteContext.Insert(n.note);
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
            NoteViewModel viewModel = new NoteViewModel();
            viewModel.note = noteToEdit;
            viewModel.codingLanguages = cContext.Collections().ToList();
            if (noteToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult Edit(NoteViewModel n, String id)
        {
            Note noteToEdit = noteContext.Find(n.note.Id);
            if (noteToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(n);
                }
                else
                {
                    noteToEdit.CodingLanguage = n.note.CodingLanguage;
                    noteToEdit.dateModified = DateTime.Now.ToString();
                    noteToEdit.Description = n.note.Description;
                    noteToEdit.NoteContent = n.note.NoteContent;
                    noteToEdit.Title = n.note.Title;
                    noteContext.Commit();
                    return RedirectToAction("Details", new { id = n.note.Id });
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