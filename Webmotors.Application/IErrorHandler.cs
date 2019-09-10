using System;
using System.Collections.Generic;
using System.Text;

namespace Webmotors.Application
{
    public interface IErrorHandler
    {
        void Error(string message);
    }
}
