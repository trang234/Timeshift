using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TimeshiftBLL.BLL;

namespace TimeshiftAPI.Controllers
{
    [RoutePrefix("TimeshiftAPI")]
    public class TimeshiftController : ApiController
    {
        private Timeshift timeShift = new Timeshift();

        [Route("GetCurrentSystemTime")]
        [HttpGet]
        public string GetCurrentSystemTime()
        {
            return timeShift.GetCurrentDateTime();
        }

        [Route("SetSystemTime/{expDateTime}")]
        [HttpGet]
        public IHttpActionResult SetDateTime(string expDateTime)
        {
            DateTime dt = DateTime.ParseExact(expDateTime,
                "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            if (timeShift.ChangeDateTime(dt))
                return Ok(timeShift.GetCurrentDateTime());
            return StatusCode(HttpStatusCode.NotModified);
        }
    }
}
