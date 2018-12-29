using BookmarksAPI.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BookmarksAPI.Models;
using System.Web.Http.Cors;

namespace BookmarksAPI.Controllers
{
    [RoutePrefix("api/sessionstorage")]
    public class SessionStorageController : ApiController
    {
        // GET: api/SessionStorage
        //default 'get' method: return all available session keys
        [Route("")]
        public IEnumerable<string> Get()
        {
            return System.Web.HttpContext.Current.Session.Keys.Cast<string>();
        }

        // GET: api/SessionStorage/key_name       
        [Route("{key}")]
        public JsonResult<object> Get(string key)
        {
            return Json<object>(System.Web.HttpContext.Current.Session[key]);

        }

        // POST: api/SessionStorage/save
        [HttpPost]
        [Route("save")]
        public void Post([FromBody] BaseRequest request)
        {
            
            List<object> sessionList = System.Web.HttpContext.Current.Session[Utils.BOOKMARKS_SESSION_KEY] as List<object>;
            sessionList = sessionList ?? new List<object>();
            sessionList.Add(request.item);

            System.Web.HttpContext.Current.Session[Utils.BOOKMARKS_SESSION_KEY] = sessionList;

        }

        // PUT: api/SessionStorage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SessionStorage/5
        public void Delete(int id)
        {
        }
    }
}
