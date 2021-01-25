using System;
using System.Collections.Generic;
using System.Text;

namespace TscDll.Entities
{
    public class ResponseData
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage
        {
            set { }
            get
            {
                return "Ошибка";
            }
        }
        public object Data { get; set; }
    }
}
