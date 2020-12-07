using System;

namespace Pazar.Core.Exceptions
{
    public class NullException : Exception
    {
        public NullException()
        : base()
        {
        }

        public NullException(string message)
            : base(message)
        {
        }

        public NullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NullException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
