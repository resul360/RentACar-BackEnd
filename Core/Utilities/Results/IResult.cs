using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } // başarı durumunu oku (set kur)
        string Message { get; } // işlem sonucuna bağlı bilgi mesajı
    }
}
