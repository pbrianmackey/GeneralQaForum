using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feedback.Controllers
{
    public class GeneralApiController : ApiController
    {
        // GET api/api
        public void CreateQuestionComment(string comment)
        {
            
        }

        // GET api/api/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/api
        public void Post([FromBody]string value)
        {

        }

        // PUT api/api/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/api/5
        public void Delete(int id)
        {
        }
    }
}
