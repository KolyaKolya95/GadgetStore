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
    public class SerApiController : ApiController
    {

        private IGadgetRepository repository;
        

        public SerApiController(IGadgetRepository repo)
        {

            repository = repo;
        }

        [HttpGet]
        [Route("api/smart/hello")]
        public string Get()
        {
            return "Hello world " + DateTime.Now.ToShortDateString();
        }


        [HttpDelete]
        [Route("api/smart/{id})")]
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
        [Route("api/smart/add")]
        public string Create([FromBody]Gadget  gadgetpost)
        {
            Gadget gadget = new Gadget();

            if (ModelState.IsValid)
            {
                gadget.Name = gadgetpost.Name;
                gadget.Type = gadgetpost.Type;
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
