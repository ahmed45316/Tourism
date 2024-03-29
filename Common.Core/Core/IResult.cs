﻿using System;
using System.Net;

namespace Common.Core.Core
{
    public interface IResult
    {
        object Data { get; set; }
        HttpStatusCode Status { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
