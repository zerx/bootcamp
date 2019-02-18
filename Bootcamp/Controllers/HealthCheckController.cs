using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Bootcamp.Controllers
{
    public class HealthCheckController : ApiController
    {
        // GET api/healthcheck
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DateTime.Now);
        }
    }
}