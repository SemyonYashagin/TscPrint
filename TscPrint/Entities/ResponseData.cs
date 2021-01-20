using System;
using System.Collections.Generic;
using System.Text;

namespace TscDll.Entities
{
    public class ResponseData
    {
        public bool isSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
