//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models
{
    /// <summary>
    /// Represents a base work (e.g., book, magazine, newspaper) with a unique ID and common properties.
    /// </summary>
    [CLSCompliant(true)]
    public abstract class Work
    {
        #region Properties

        /// <summary>
        /// Gets the unique ID of the work.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets or sets the title of the work.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the work.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the language of the work.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the format of the work.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the work.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the year of publication.
        /// </summary>
        public int Year { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Work"/> class.
        /// </summary>
        /// <param name="title">The title of the work.</param>
        /// <param name="author">The author of the work.</param>
        /// <param name="language">The language of the work.</param>
        /// <param name="format">The format of the work.</param>
        /// <param name="publisher">The publisher of the work.</param>
        /// <param name="year">The year of publication.</param>
        protected Work(string title, string author, string language, string format, string publisher, int year)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            Format = format ?? throw new ArgumentNullException(nameof(format));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Year = year;

            GenerateID();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a new globally unique ID for the work.
        /// </summary>
        private void GenerateID()
        {
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// Closes the work. Must be implemented by derived classes.
        /// </summary>
        public abstract void CloseWork();

        #endregion
    }
}