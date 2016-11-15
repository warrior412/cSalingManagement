using BusinessEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace cSalingManagementWeb.Controllers
{
    public class ImageController : ApiController
    {
        public string PostProductImage()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            status.StatusCode = StatusCodes.NO_DATA;
            var filePath = "";
            var fileName = "";
            try
            {
                var httpRequest = HttpContext.Current.Request;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        //int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            fileName = "";
                            status.StatusCode = StatusCodes.FILE_FORMAT_ERROR; 
                        }
                        //else if (postedFile.ContentLength > MaxContentLength)
                        //{

                        //    var message = string.Format("Please Upload a file upto 1 mb.");

                        //    dict.Add("error", message);
                        //    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        //}
                        else
                        {
                            //  where you want to attach your imageurl
                            //if needed write the code to update the table
                            DateTime date = DateTime.Now;
                            fileName = date.Year+""+date.Month + "" + date.Year + "" + date.Hour + "" + date.Minute + "" + date.Second + "" + date.Millisecond + "" + extension;
                            filePath = HttpContext.Current.Server.MapPath("~/Images/ProductImages/" + fileName);
                            //Userimage myfolder name where i want to save my image
                            postedFile.SaveAs(filePath);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                fileName = ex.Message;
                status.StatusCode = StatusCodes.UNKNOW_ERROR;
            }
            returnData.Status = status;
            returnData.Data = fileName;
            JsonSerializerSettings st = new JsonSerializerSettings();
            return JsonConvert.SerializeObject(returnData, Formatting.None, st);
        }
    }
}
