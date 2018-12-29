using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookmarksAPI.App_Code
{
    public class Utils
    {
        public const string BOOKMARKS_SESSION_KEY = "ssn_usrbkmrks";

        public static string GetJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}