using System;

namespace Mybarber.Exceptions
{
    public class BusinessException : Exception
    {

        public  class CNPJException : Exception
        {
            public CNPJException(string message) : base(message) { }
        }
    }
}
