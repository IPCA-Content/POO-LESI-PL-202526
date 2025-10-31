//-----------------------------------------------------------------
//    <copyright file="CustomException.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>30-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_7
{
    /// <summary>
    /// Represents a custom exception that logs its error message to a file when thrown.
    /// Inherits from the base <see cref="Exception"/> class.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class
        /// with a specified error message and automatically logs it to a file.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomException(string message) : base(message)
        {
            LogError(message);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Logs the error message to a text file ("log_error.txt") located in the application's working directory.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        private void LogError(string message)
        {
            string logFile = "log_error.txt"; // File path for logging
            string finalMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
            File.AppendAllText(logFile, finalMessage);
        }

        #endregion
    }
}