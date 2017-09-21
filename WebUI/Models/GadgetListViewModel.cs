using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class GadgetListViewModel
    {
        public IEnumerable<Gadget> Gadgets { get; set; }
        public IEnumerable<StatisticsModel> modelMaping { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }

        public int Count { get; set; }
    }
}