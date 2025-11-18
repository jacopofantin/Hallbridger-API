using System;
using System.Web;
using System.Web.Http;
using Hallbridger_API.Parsers;

namespace Hallbridger_API.Controllers
{
    [RoutePrefix("api/import")]
    public class ImportController : ApiController
    {
        [HttpPost]
        [Route("txt")]
        public IHttpActionResult ImportTxt()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count == 0)
                    return BadRequest("No file uploaded.");

                var file = httpRequest.Files[0];
                var data = TxtParser.Parse(file.InputStream);

                return Ok(data);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}