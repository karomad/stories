using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Helpers
{
    public class ResponseData
    {
        public static ResponseData ErrorDefault = new ResponseData { Status = 500, Error = "An error occured" };
        public ResponseData()
        {
            Status = 200;//default is OK
        }
        public int Status { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }
    }
}