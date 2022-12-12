namespace MichaelChecksum.Console
{
	/// <summary>
	/// Possible return codes
	/// </summary>
	public enum ExitCode : int
	{
		/// <summary>
		/// Indicates that the program exited successfully
		/// </summary>
		Success = 0,
		/// <summary>
		/// Indicates that the file to calculate the hash for was not specified
		/// </summary>
		FileNotSpecified,
		/// <summary>
		/// Indicates that the path/address of the file to calculate the hash for was in an invalid format.
		/// </summary>
		FilePathInvalidFormat,
		/// <summary>
		/// Indicated that the specified file is not found.
		/// </summary>
		FileNotFound,
		/// <summary>
		/// Indicated that access to the specified file has been denied.
		/// </summary>
		AccessDenied
	}
}
