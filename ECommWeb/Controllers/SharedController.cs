using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommWeb.Controllers
{
    public class SharedController : Controller
    {
       public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0]; // first file
                //var fileName = file.FileName;
                //it will generate unique name by adding different characters, so that no one can guess image name
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("~/content/images/"), fileName);

                file.SaveAs(path); // save file in this path

                result.Data = new { Success = true, ImageURL = string.Format("/content/images/{0}", fileName) }; 
               
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            return result;
        }
    }
}