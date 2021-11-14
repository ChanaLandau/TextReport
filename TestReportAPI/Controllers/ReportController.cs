using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TextReportBL;

namespace TestReportAPI.Controllers
{
  //  [Route("")]
    public class ReportController : ApiController
    {
    //    [HttpGet]
    //    [Route("aa")]
    //    public IHttpActionResult Get()
    //    {
    //       return Ok( SharedLogic.get());
    //    }

        [HttpPost]
        [Route("api/upload")]
        public async Task<IHttpActionResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName;
                var buffer = await file.ReadAsByteArrayAsync();
                string path = @"C:\Users\USER\Desktop\aaa.txt";
               // string path = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "dataset.csv");
                //  var filesPath = Directory.GetCurrentDirectory() + "/Uploadfiles";
                //Console.WriteLine(File.ReadLines().Count())
                //Do whatever you want with filename and its binary data.
                return Ok(SharedLogic.GetText(path));
            }

            return Ok("dd");
        }


        [HttpPost]
        [Route("api/cc")]
        public HttpResponseMessage Post2()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                }



                result = Request.CreateResponse(HttpStatusCode.OK, Console.WriteLine(File.ReadLines(filePath).Count()));


            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}
