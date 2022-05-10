using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Result
{
    public class ExceptionResult : Result
    {
        public ExceptionResult() : base(ResultStatus.Exception, "")
        {

        }

        public ExceptionResult(Exception exception, bool showException = true)
            : base(ResultStatus.Exception,
                 showException ?
                 (exception != null ?
                 "Exception:" + exception.Message + (exception.InnerException != null ?
                 "| Inner Exception" + exception.InnerException.Message + (exception.InnerException.InnerException != null ?
                 "|" + exception.InnerException.InnerException.Message
                     : "")
                    : "")
                   : "")
                 : "")
        {



        }
    }

    public class ExceptionResult<TResultType> : Result<TResultType>
    {
        public ExceptionResult() : base(ResultStatus.Exception, "",default)
        {

        }

        public ExceptionResult(Exception exception, bool showException = true)
            : base(ResultStatus.Exception,
                 showException ?
                 (exception != null ?
                 "Exception:" + exception.Message + (exception.InnerException != null ?
                 "| Inner Exception" + exception.InnerException.Message + (exception.InnerException.InnerException != null ?
                 "|" + exception.InnerException.InnerException.Message
                     : "")
                    : "")
                   : "")
                 : "",default)
        {



        }
    }

}
