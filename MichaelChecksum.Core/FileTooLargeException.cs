using System;
using System.Runtime.Serialization;

namespace MichaelChecksum.Core
{
    /// <summary>
    /// <see cref="FileTooLargeException" /> is thrown when....
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public class FileTooLargeException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileTooLargeException" /> class.
        /// </summary>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        public FileTooLargeException() : this("File is too large", (string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTooLargeException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        public FileTooLargeException(string message) : this(message, (string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTooLargeException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) is not inner exception is specified.</param>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        public FileTooLargeException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FileTooLargeException" /> class.
        /// </summary>
        public FileTooLargeException(string message, string paramName) : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTooLargeException" /> class.
        /// </summary>
        public FileTooLargeException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        /// <summary>
        /// Constructor for deserialization
        /// </summary>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        protected FileTooLargeException(
              SerializationInfo info,
              StreamingContext context)
                : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
