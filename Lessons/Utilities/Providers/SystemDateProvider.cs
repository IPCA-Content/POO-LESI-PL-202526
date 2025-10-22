//-----------------------------------------------------------------
//    <copyright file="SystemDateProvider.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:35</time>
//    <version>1.0</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using DatesUtilities.Interfaces;

namespace DatesUtilities.Providers
{
    /// <summary>
    /// Provides the current system date using <see cref="DateTime.Now"/>.
    /// This is the default implementation of <see cref="IDateProvider"/>
    /// used in production environments.
    /// </summary>
    public class SystemDateProvider : IDateProvider
    {
        #region Properties

        /// <summary>
        /// Gets today's date based on the system's current date and time.
        /// </summary>
        public DateOnly Today => DateOnly.FromDateTime(DateTime.Now);

        #endregion
    }
}