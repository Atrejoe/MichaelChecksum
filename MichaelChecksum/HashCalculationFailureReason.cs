namespace MichaelChecksum
{
    /// <summary>
    /// The reason for failing hash calculation
    /// </summary>
    public enum HashCalculationFailureReason
    {
        /// <summary>
        /// The other
        /// </summary>
        Other,
        /// <summary>
        /// The file to calculate was too large
        /// </summary>
        TooLarge,
        /// <summary>
        /// There was an issue obtaining the file.
        /// </summary>
        Connectivity,
        /// <summary>
        /// There was an issue obtaining the fil: the file does not exist
        /// </summary>
        NotFound
    }
}