//-----------------------------------------------------------------
//    <copyright file="DateUtilsTests.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:00</time>
//    <version>0.2</version>
//    <author>Ernesto Casanova</author>
//    <summary>
//      Unit tests for DateUtils class using a FakeDateProvider
//      to ensure deterministic and repeatable tests.
//    </summary>
//-----------------------------------------------------------------

using DatesUtilities.Providers;
using DateUtilities;

namespace DateUtilitiesTests
{
    /// <summary>
    /// Contains test cases for verifying the behavior of <see cref="DateUtils"/>.
    /// Uses a <see cref="FakeDateProvider"/> to fix the current date to 22/10/2025.
    /// </summary>
    [TestFixture]
    public class DateUtilsTests
    {
        #region Private Fields

        /// <summary>
        /// Instance of the class under test.
        /// </summary>
        private DateUtils _dateUtils;

        /// <summary>
        /// Provides a fixed date for deterministic test results.
        /// </summary>
        private FakeDateProvider _fakeProvider;

        #endregion

        #region Setup

        /// <summary>
        /// Initializes test dependencies before each test runs.
        /// Sets the current date to 22 October 2025.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _fakeProvider = new FakeDateProvider(new DateOnly(2025, 10, 22));
            _dateUtils = new DateUtils(_fakeProvider);
        }

        #endregion

        #region Age(DateOnly) Tests

        /// <summary>
        /// Tests the Age(DateOnly) method with multiple realistic and edge case scenarios.
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <param name="day">Day of birth.</param>
        /// <param name="expected">Expected age result.</param>
        [TestCase(2020, 01, 01, 5)]   // Early in the year - birthday already passed
        [TestCase(2020, 12, 31, 4)]   // End of the year - birthday not yet reached
        [TestCase(2020, 10, 22, 5)]   // Birthday today
        [TestCase(2020, 10, 23, 4)]   // Birthday tomorrow
        [TestCase(2020, 10, 21, 5)]   // Birthday yesterday
        [TestCase(2019, 10, 22, 6)]   // Older birth year, same month/day
        [TestCase(2024, 02, 29, 1)]   // Leap day - should work correctly on non-leap years
        [TestCase(2025, 10, 22, 0)]   // Born today → age 0
        [TestCase(2026, 01, 01, -1)]  // Future date → negative age
        [TestCase(1900, 01, 01, 125)] // Very old date
        [TestCase(2020, 02, 29, 5)]   // Leap birthday before current date in a non-leap year
        [TestCase(2020, 03, 01, 5)]   // Just after February → correct boundary
        [TestCase(2020, 09, 30, 5)]   // Birthday last month → already passed
        [TestCase(2020, 11, 30, 4)]   // Birthday next month → not yet passed
        [TestCase(2024, 12, 31, 0)]   // End of current year → not yet turned 1
        public void TestAgeWithDateOnly(int year, int month, int day, int expected)
        {
            // Arrange
            DateOnly date = new DateOnly(year, month, day);

            // Act
            int actual = _dateUtils.Age(date);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Age(int year, int month, int day) Tests

        /// <summary>
        /// Tests the Age(int, int, int) overload to confirm correct age calculation
        /// when separate year, month, and day parameters are passed.
        /// </summary>
        /// <param name="year">Year of birth.</param>
        /// <param name="month">Month of birth.</param>
        /// <param name="day">Day of birth.</param>
        /// <param name="expected">Expected calculated age.</param>
        [TestCase(2020, 01, 01, 5)]  // Birthday passed this year
        [TestCase(2020, 12, 01, 4)]  // Birthday not yet reached
        [TestCase(2020, 11, 01, 4)]  // Birthday next month
        [TestCase(2025, 10, 22, 0)]  // Born today
        [TestCase(2026, 10, 22, -1)] // Future date
        public void TestAgeWithYearMonthDay(int year, int month, int day, int expected)
        {
            // Act
            int actual = _dateUtils.Age(year, month, day);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
