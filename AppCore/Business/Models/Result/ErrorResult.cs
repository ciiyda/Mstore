using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Result
{

    public class ErrorResult : Result
    {
        public ErrorResult() : base(ResultStatus.Error, "")
        {

        }

        public ErrorResult(string message) : base(ResultStatus.Error, message)
        {

        }

    }

    public class ErrorResult<TResultType> : Result<TResultType>
    {
        public ErrorResult() : base(ResultStatus.Error, "", default)
        {

        }

        public ErrorResult(TResultType data) : base(ResultStatus.Error, "", data)
        {

        }

        public ErrorResult(string message) : base(ResultStatus.Error, message, default)
        {

        }


        public ErrorResult(string message, TResultType data) : base(ResultStatus.Error, message, data)
        {

        }


    }

}
