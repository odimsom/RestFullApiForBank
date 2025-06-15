using System.Globalization;

namespace RestFullApiForBank.Core.Application.Exeptions
{
    public class ApiExeptions : Exception
    {
        public ApiExeptions() : base() { }

        public ApiExeptions(string message) : base(message) { }
        public ApiExeptions(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}