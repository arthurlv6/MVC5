using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebSite.Filters
{
    public class ExcelResult:ActionResult
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {

            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            var canprocess = request.AcceptTypes.Contains("application/vnd.ms-excel");
            //if (canprocess)
            //{
                response.Clear();
                response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                response.ContentType = "application/vnd.ms-excel";
                response.WriteFile(context.HttpContext.Server.MapPath(Path));
            //}
        }
    }
}
