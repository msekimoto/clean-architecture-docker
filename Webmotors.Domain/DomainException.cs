using System;
using System.Collections.Generic;
using System.Text;

namespace Webmotors.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage) : base(businessMessage) { }
    }
}
