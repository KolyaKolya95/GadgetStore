using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public  class PagingInfo
    {
        public int TotatlItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPagase
        {
            get { return (int)Math.Ceiling((decimal)TotatlItems / ItemsPerPage); }
        }
    }
}