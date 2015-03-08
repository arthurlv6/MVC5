using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebSite.Filters;

namespace WebSite.Controllers
{
    public class ExcelFilesController : Controller
    {
     
        public ActionResult ViewFile(int id)
        {
            Contract.Requires<ArgumentException>(id > 0);

            var path = string.Format("~/Files/temp0{0}.xlsx", id);
            return new ExcelResult
            {
                FileName = "sample.xlsx",
                Path = path
            };
        }
    }
}