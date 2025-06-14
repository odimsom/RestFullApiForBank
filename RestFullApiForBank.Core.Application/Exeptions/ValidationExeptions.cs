using FluentValidation.Results;

namespace RestFullApiForBank.Core.Application.Exeptions
{
    public class ValidationExeptions : Exception
    {
        public List<string> Errors { get; }
        public ValidationExeptions() : base("Se an producido uno o mas errores de validacion")
        {
            Errors = new List<string>();
        }
        public ValidationExeptions(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
