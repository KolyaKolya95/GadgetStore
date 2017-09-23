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
    public class ListApiController : ApiController
    {
        private IGadgetRepository repository;

        public ListApiController(IGadgetRepository repo)
        {

            repository = repo;
        }

        [HttpGet]
        [Route("api/list/{id}")]
        public string GetHello(int id)
        {
            return "Hello word " + id;
        }

        [HttpPost]
        [Route("api/list/add")]
        public Gadget Create([FromBody]Gadget gadgetPost)
        {
            Gadget gadget = new Gadget();
           

            if (ModelState.IsValid)
            {
                gadget.Name = gadgetPost.Name;
                gadget.Type = gadgetPost.Type;
                repository.AddGadget(gadget);
                return gadget;
            }
            else
            {
                return gadget;
            }
        }

        [HttpDelete]
        [Route("api/list/{id}")]
        public string Delete(int id)
        {
            repository.DeleteGadgetAPI(id); 

            return "Gadget delete "  + id;
        }
    }
}
