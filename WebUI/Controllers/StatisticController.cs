using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using System.Diagnostics;
using System.Collections;

namespace WebUI.Controllers
{
    public class StatisticController : Controller
    {

        private IGadgetRepository repository;
        public int pageSize = 3;

        public StatisticController(IGadgetRepository repo)
        {
            repository = repo;
        }

        // GET: Statistic
        public ViewResult StaticsList()
        {
            StatisticsModel model = new StatisticsModel();
            model.Map = new Dictionary<string, int>();

            foreach (var m in repository.Gadgets)
            {
                int count = 0;

                if (model.Map.TryGetValue(m.Type, out count))
                {
                            
                  model.Map[m.Type] = count + 1;
                 }
                 else
                 {
                   model.Map[m.Type] = 1;
                 }
            }
            return View(model);
        }


       

        public JsonResult get_data(int pageindex, int pagesize)
        {
            regsiterlist rslist = new regsiterlist();
            rslist.totalcount = repository.Gadgets.Count();
            return Json(rslist, JsonRequestBehavior.AllowGet);
        }
    }
}