using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        // T hangi tip döndüreceğini bana söyle
        T Data { get; }

    }
}
