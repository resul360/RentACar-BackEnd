using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message)//base şu iki bilgi yolla
        {
            Data = data; // bu hali ile data set edemeyeceği için yandaki kodtaki gibi data tekrardan set edilir.
        }
        public DataResult(T data, bool success) : base(success)// Message yollamak istemezse, overload ediyoruz.
        {
            Data = data;
        }
        public T Data { get; }
    }
}
