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
        IRepository<NoteUser> userContext;
        IRepository<NoteType> typeContext;
        public HomeController(IRepository<Note> noteContext, IRepository<CodingLanguage> cContext, IRepository<NoteUser> userContext, IRepository<NoteType> typeContext)
        {
            this.noteContext = noteContext;
            this.cContext = cContext;
            this.userContext = userContext;
            this.typeContext = typeContext;
        }
        public ActionResult Index(string codingLanguage=null,string noteType=null)
        {
            
            List<CodingLanguage> codingLanguages = cContext.Collections().ToList();
            List<NoteType> noteTypes = typeContext.Collections().ToList();
            List<Note> notes;
            if (codingLanguage == null && noteType==null)
            {
                notes = noteContext.Collections().ToList();
            }
            else if(noteType==null)
            {
                notes = noteContext.Collections().Where(n => n.CodingLanguage == codingLanguage).ToList();
            }
            else if (codingLanguage == null)
            {
                notes = noteContext.Collections().Where(n => n.NoteType == noteType).ToList();
            }
            else
            {
                notes = noteContext.Collections().Where(n => n.NoteType == noteType).Where(n=>n.CodingLanguage==codingLanguage).ToList();
            }
            NoteListViewModel viewModel = new NoteListViewModel();
            viewModel.notes = notes;
            viewModel.codingLanguages = codingLanguages;
            viewModel.noteTypes = noteTypes;
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            NoteViewModel viewModel = new NoteViewModel();
            viewModel.note = new Note();
            viewModel.noteTypes = typeContext.Collections().ToList();
            viewModel.codingLanguages = cContext.Collections().ToList();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(NoteViewModel n)
        {
            if (!ModelState.IsValid)
            {
                return View(n);
            }
            else
            {
                NoteUser noteUser = userContext.Collections().FirstOrDefault(i => i.Email == User.Identity.Name);
                if (noteUser != null)
                {
                    n.note.UserEmail = noteUser.Email;
                }
                n.note.dateModified = n.note.createdAt.ToString();
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

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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
        [Authorize]
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