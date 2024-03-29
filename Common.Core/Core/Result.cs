﻿using System;
using System.Net;

namespace Common.Core.Core
{
    public class Result : IResult
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
