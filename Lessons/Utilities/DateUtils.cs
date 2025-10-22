//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using DatesUtilities.Interfaces;

namespace DateUtilities
{
    /// <summary>
    /// Provides utility methods for date calculations, such as computing age.
    /// </summary>
    public class DateUtils
    {
        #region Construtor 
        /// <summary>
        /// Date Provider Property
        /// </summary>
        private readonly IDateProvider _dateProvider;

        /// <summary>
        /// Contructor Date Utils
        /// </summary>
        /// <param name="dateProvider"></param>
        public DateUtils(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }
        #endregion
        
        #region Methods

        /// <summary>
        /// Calculates the age in years from a given <see cref="DateOnly"/> birth date.
        /// </summary>
        /// <param name="date">The birth date.</param>
        /// <returns>The age in years.</returns>
        public int Age(DateOnly date)
        {
            DateOnly today = _dateProvider.Today;
            int age = today.Year - date.Year;
            if (date > today.AddYears(-age)) age--;
            return age;
        }

        /// <summary>
        /// Calculates the age in years from a specified year, month, and day.
        /// </summary>
        /// <param name="year">The birth year.</param>
        /// <param name="month">The birth month.</param>
        /// <param name="day">The birth day.</param>
        /// <returns>The age in years.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the date is invalid or in the future.
        /// </exception>
        public int Age(int year, int month, int day)
        {
            return Age(new DateOnly(year, month, day)); // reuse Age(DateOnly) method ??
        }

        #endregion
    }
}