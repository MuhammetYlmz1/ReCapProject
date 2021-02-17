using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public class ErrorResult:Result
    {
        //Bu da Başarısız durumlarda çalıştırılacak
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }

    }
}
