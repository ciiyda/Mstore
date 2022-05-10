﻿using AppCore.Business.Models.Result.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Result
{
    public class Result
    {
        public ResultStatus Status { get; }

        public string Message { get; set; }

        public Result(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }

    public class Result<TResultType> : Result, IResultData<TResultType>
    {
        public TResultType Data { get; }

        public Result(ResultStatus status,string message, TResultType data):base(status,message)
        {
            Data = data;
        }
    }



}
