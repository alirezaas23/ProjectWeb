using System;

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
