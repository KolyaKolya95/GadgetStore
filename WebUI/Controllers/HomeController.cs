using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IGadgetRepository repository;
        public int pageSize = 4;

        public HomeController(IGadgetRepository repo)
        {
           
            repository = repo;
        }

        // GET: Home
        public ViewResult Index(string type, int page = 1)
        {
            GadgetListViewModel model = new GadgetListViewModel
            {
                Gadgets = repository.Gadgets
                .Where(b => type == null || b.Type == type)
                .OrderBy(gadget => gadget.GadgetId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotatlItems = type == null ? repository.Gadgets.Count() :
                                                  repository.Gadgets.Where(book => book.Type == type).Count()
                },

                CurrentGenre = type     
        };

            Debug.WriteLine(type);

            return View(model);

        }

        public ViewResult Edite(int gadgetId)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(b =>b.GadgetId == gadgetId);
            return View(gadget);
        }

        [HttpPost]
        public ActionResult Edite(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGadget(gadget);
                TempData["message"] = string.Format("Edite save \"{0}\" gadget", gadget.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(gadget);
            }
        }

        public ViewResult Delete(int gadgetid)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(b => b.GadgetId == gadgetid);
            return View(gadget);
        }

        [HttpDelete]
        public ActionResult Delete(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteGadget(gadget);
                TempData["message"] = string.Format("Gadget delete \"{0}\" gadget", gadget.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(gadget);
            }
        }

        [HttpPost]
        public ActionResult Create(string name, string type)
        {
            Gadget gadget = new Gadget();
           
                if (ModelState.IsValid)
                {
                    gadget.Name = name;
                    gadget.Type = type;
                    repository.AddGadget(gadget);
                    TempData["message"] = string.Format("Gadget add \"{0}\" gadget", gadget.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(gadget);
                } 
        }
    }
}