using System;

namespace MichaelChecksum
{
	/// <summary>
	/// The result of hash calculation
	/// </summary>
	internal class CheckResult
	{
		public readonly DateTime LastCheck = DateTime.UtcNow;
		public TimeSpan Duration;
		public long Hits = 1;

		/// <summary>
		/// Gets or sets the hash, the result of the calculation
		/// </summary>
		/// <value>
		/// The hash.
		/// </value>
		public string? Hash { get; set; }
		/// <summary>
		/// Gets or sets the failure reason.
		/// </summary>
		/// <value>
		/// The failure reason.
		/// </value>
		public HashCalculationFailureReason? FailureReason { get; set; }
	}
}