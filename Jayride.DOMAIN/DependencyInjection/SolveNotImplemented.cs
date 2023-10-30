using System.Runtime.Serialization;

namespace Jayride.Domain.DependencyInjection
{
    [Serializable]
    public class SolveNotImplemented : Exception
    {
        public SolveNotImplemented()
        {
        }

        public SolveNotImplemented(string? message) : base(message)
        {
        }

        public SolveNotImplemented(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SolveNotImplemented(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}