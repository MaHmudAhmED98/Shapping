using System;

namespace Shapping.Handler
{
    /// <summary>
    /// Represents the user identifier provider interface.
    /// </summary>
    public interface IUserIdentifierProvider
    {
        /// <summary>
        /// Gets the authenticated user identifier.
        /// </summary>
        string UserId { get; }
    }
}
