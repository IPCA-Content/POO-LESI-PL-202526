//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace StringUtilities
{
    /// <summary>
    /// String Utils
    /// </summary>
    public static class StringUtils
    {
        #region Static Methods
        
        /// <summary>
        /// Method Is Palindrome
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string tmp = input.Trim();
            string reversed = new string(tmp.Reverse().ToArray());
            return string.Equals(tmp, reversed, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Method Capitalize First
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            string tmp = input.Trim();
            
            return char.ToUpper(tmp[0]) + tmp.Substring(1).ToLower();
        }
        #endregion
    }
}