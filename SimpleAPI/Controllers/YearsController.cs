using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleAPI.Controllers
{
    public class Years {
        public Years(int year)
        {
            Year = year;
        }

        public int Year { get; } }
    
    public class YearsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DateTime.Now.Year);
        }

        [HttpPost]
        public HttpResponseMessage Calculate([FromBody]Years year)
        {
            if (year.Year <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot calculate dates before year 1.");
            }

            var result = DateTime.Now.Year - year.Year;
            return Request.CreateResponse(HttpStatusCode.Created, result);

        }
    }
}