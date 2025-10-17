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
    /// Represents a scientific book, derived from <see cref="Work"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class CientificBook : Work
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ISBN of the scientific book.
        /// </summary>
        public int ISBN { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CientificBook"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="language">The language of the book.</param>
        /// <param name="format">The format of the book.</param>
        /// <param name="publisher">The publisher of the book.</param>
        /// <param name="year">The year of publication.</param>
        /// <param name="isbn">The ISBN number.</param>
        public CientificBook(string title, string author, string language, string format, string publisher, int year, int isbn)
            : base(title, author, language, format, publisher, year)
        {
            ISBN = isbn;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the title of the book.
        /// </summary>
        /// <param name="id">The ID (currently not used in output).</param>
        public void GetTitle(int id)
        {
            // Optional: you could use id in the future for something
            Console.WriteLine($"Title: {Title}");
        }

        /// <summary>
        /// Closes the work. Overrides the base <see cref="Work.CloseWork"/> method.
        /// </summary>
        public override void CloseWork()
        {
            Console.WriteLine($"Scientific book '{Title}' has been closed.");
        }

        #endregion
    }
}