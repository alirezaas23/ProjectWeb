using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Generators
{
    public static class CodeGenerators
    {
        public static string CreateActivationCode()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
