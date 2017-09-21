using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class WebAppiController : ApiController
    {

        private IGadgetRepository repository;
        

        public WebAppiController(IGadgetRepository repo)
        {

            repository = repo;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello world " + DateTime.Now.ToShortDateString();
        }


        [HttpDelete]
        public string DeleteGadgetApi(int gadgetId)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(b => b.GadgetId == gadgetId);
            if (ModelState.IsValid)
            {
                repository.DeleteGadget(gadget);
                return "Delete";
            }
            else
            {
                return "Not found Id gadget";
            }

        }

        [HttpPost]
        public string Create(string name, string type)
        {
            Gadget gadget = new Gadget();

            if (ModelState.IsValid)
            {
                gadget.Name = name;
                gadget.Type = type;
                repository.AddGadget(gadget);
               
                return "Add to : " + gadget.Name;
            }
            else
            {
                return "error";
            }
        }
    }
}
