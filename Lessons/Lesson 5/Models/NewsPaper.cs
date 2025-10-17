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
    /// Represents a newspaper, derived from <see cref="Work"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class NewsPaper : Work
    {
        #region Properties

        /// <summary>
        /// Gets or sets the month of publication.
        /// </summary>
        public int Month { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsPaper"/> class.
        /// </summary>
        /// <param name="title">The title of the newspaper.</param>
        /// <param name="author">The author of the newspaper.</param>
        /// <param name="language">The language of the newspaper.</param>
        /// <param name="format">The format of the newspaper.</param>
        /// <param name="publisher">The publisher of the newspaper.</param>
        /// <param name="year">The year of publication.</param>
        /// <param name="month">The month of publication.</param>
        public NewsPaper(string title, string author, string language, string format, string publisher, int year, int month)
            : base(title, author, language, format, publisher, year)
        {
            Month = month;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the edition of the newspaper.
        /// </summary>
        /// <param name="id">The edition ID.</param>
        public void GetEdition(int id)
        {
            Console.WriteLine($"{Title} has edition {id}");
        }

        /// <summary>
        /// Closes the newspaper. Overrides the base <see cref="Work.CloseWork"/> method.
        /// </summary>
        public override void CloseWork()
        {
            Console.WriteLine($"Newspaper '{Title}' has been closed.");
        }

        #endregion
    }
}