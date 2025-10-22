//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using StringUtilities;

namespace StringUtilsTests
{
    /// <summary>
    /// Unit tests for <see cref="StringUtils"/> methods.
    /// Tests include palindrome checking and first letter capitalization.
    /// </summary>
    [TestFixture]
    public class StringUtilsTests
    {
        #region Setup

        /// <summary>
        /// Setup method executed before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // No initialization required for these tests
        }

        #endregion

        #region IsPalindrome Tests

        /// <summary>
        /// Tests <see cref="StringUtils.IsPalindrome(string?)"/> with multiple cases.
        /// Handles normal words, empty strings, null, whitespace, and case-insensitivity.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <param name="expected">Expected result: true if palindrome, false otherwise.</param>
        [TestCase("civic", true)]
        [TestCase("rotor", true)]
        [TestCase("radar", true)]
        [TestCase("madam", true)]
        [TestCase("cebolas", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("Madam", true)]
        [TestCase(" madam", true)]
        [TestCase(" madam ", true)]
        [TestCase(" madam                       ", true)]
        public void TestIsPalindrome(string? word, bool expected)
        {
            // Act
            bool actual = StringUtils.IsPalindrome(word);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region CapitalizeFirstLetter Tests

        /// <summary>
        /// Tests <see cref="StringUtils.CapitalizeFirstLetter(string?)"/> with multiple cases.
        /// Handles words, empty strings, null, whitespace, and correct capitalization.
        /// </summary>
        /// <param name="word">The word to capitalize.</param>
        /// <param name="expected">Expected string after capitalization.</param>
        [TestCase("33333", "33333")]
        [TestCase("a^", "A^")]
        [TestCase("^a", "^a")]
        [TestCase("civic", "Civic")]
        [TestCase("rotor", "Rotor")]
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("madaM", "Madam")]
        [TestCase("TODAY", "Today")]
        [TestCase(" madam", "Madam")]
        [TestCase(" madam ", "Madam")]
        [TestCase(" madam                      ", "Madam")]
        public void TestCapitalizeFirstLetter(string? word, string expected)
        {
            // Act
            string actual = StringUtils.CapitalizeFirstLetter(word);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
