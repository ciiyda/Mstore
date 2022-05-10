using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(ResultStatus.Success, "")
        {

        }

        public SuccessResult(string message) : base(ResultStatus.Success, message)
        {

        }

    }

    public class SuccessResult<TResultType> : Result<TResultType>
    {
        public SuccessResult() : base(ResultStatus.Success, "", default)
        {

        }

        public SuccessResult(TResultType data) : base(ResultStatus.Success, "", data)
        {

        }

        public SuccessResult(string message) : base(ResultStatus.Success, message, default)
        {

        }


        public SuccessResult(string message, TResultType data) : base(ResultStatus.Success, message, data)
        {

        }


    }
}
