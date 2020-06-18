using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Contract
{
    public class MessageModel<T>
    {
        public int Status { get; set; } = 200;
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "Error";
        public T Response { get; set; }
    }
}
