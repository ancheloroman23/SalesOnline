﻿namespace SalesOnline.Web.Models.Responses
{
    public class BaseResponse<T>
    {
        public bool success { get; set; }
        public object message { get; set; }
        public T data { get; set; }
    }
}
