//-----------------------------------------------------------------
//    <copyright file="FakeDateProvider.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:30</time>
//    <version>1.0</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using DatesUtilities.Interfaces;

namespace DatesUtilities.Providers
{
    /// <summary>
    /// Represents a date provider that always returns a fixed date.
    /// This is typically used in unit testing to ensure deterministic results.
    /// </summary>
    public class FakeDateProvider : IDateProvider
    {
        #region Fields
        /// <summary>
        /// Holds the fixed date used for testing.
        /// </summary>
        private readonly DateOnly _fixedDate;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDateProvider"/> class
        /// with a predefined fixed date value.
        /// </summary>
        /// <param name="fixedDate">The date to be used as "today" in tests.</param>
        public FakeDateProvider(DateOnly fixedDate)
        {
            _fixedDate = fixedDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the fixed date value defined during construction.
        /// </summary>
        public DateOnly Today => _fixedDate;
        #endregion
    }
}