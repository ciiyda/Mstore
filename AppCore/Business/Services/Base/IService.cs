using AppCore.Business.Models.Result;
using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore.Business.Services.Base
{
    public interface IService<TModel>: IDisposable where TModel:RecordBase, new()
    {
        IQueryable<TModel> Query();
        Result Add(TModel model);

        Result Update(TModel model);

        Result Delete(int id);

    }
}
