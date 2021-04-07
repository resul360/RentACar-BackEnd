using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)
        {
            //true default verildi.

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
