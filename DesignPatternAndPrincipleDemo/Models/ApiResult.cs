using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternAndPrincipleDemo.Models
{
    public class ApiResult
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public dynamic DataResult { get; set; }
    }
}