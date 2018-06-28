using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Models
{
    public class TableData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public object data { get; set; }
    }
}