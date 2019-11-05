using System;

namespace MichaelChecksum.Core
{
    /// <summary>
    /// <see cref="FileReadException" /> is thrown when hash calculation fails.
    /// </summary>
    /// <remarks>This should encapsulate </remarks>
    [Serializable()]
    public class FileReadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileReadException" /> class.
        /// </summary>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        [Obsolete("Specify why the error ocurred.")]
        public FileReadException() : this("Failed to calculate hash")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReadException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        public FileReadException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReadException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) is not inner exception is specified.</param>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        public FileReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor for deserialization
        /// </summary>
        /// <remarks>Adhering to coding guideline: http://msdn.microsoft.com/library/ms182151(VS.100).aspx</remarks>
        protected FileReadException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
