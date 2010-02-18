using System;
using System.Runtime.Serialization;

namespace SolutionTransform
{
    [Serializable]
    public class NonErrorTerminationException : Exception
    {
        public NonErrorTerminationException()
        {
        }

        public NonErrorTerminationException(string message) : base(message)
        {
        }

        public NonErrorTerminationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NonErrorTerminationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}