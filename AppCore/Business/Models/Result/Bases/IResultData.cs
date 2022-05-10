using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Result.Bases
{
   public interface IResultData< out TResultType>

    {
        TResultType Data { get; }
    }
}
