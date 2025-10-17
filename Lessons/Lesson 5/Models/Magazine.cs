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
    /// Represents a magazine, derived from <see cref="Work"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class Magazine : Work
    {
        #region Properties

        /// <summary>
        /// Gets or sets the magazine number/issue.
        /// </summary>
        public int Number { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Magazine"/> class.
        /// </summary>
        /// <param name="title">The title of the magazine.</param>
        /// <param name="author">The author of the magazine.</param>
        /// <param name="language">The language of the magazine.</param>
        /// <param name="format">The format of the magazine.</param>
        /// <param name="publisher">The publisher of the magazine.</param>
        /// <param name="year">The year of publication.</param>
        /// <param name="number">The magazine issue number.</param>
        public Magazine(string title, string author, string language, string format, string publisher, int year, int number)
            : base(title, author, language, format, publisher, year)
        {
            Number = number;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the title of the magazine.
        /// </summary>
        /// <param name="id">The ID (currently unused).</param>
        public void GetTitle(int id)
        {
            // Optional: id parameter can be used later
            Console.WriteLine($"Title: {Title}");
        }

        /// <summary>
        /// Closes the magazine. Overrides the base <see cref="Work.CloseWork"/> method.
        /// </summary>
        public override void CloseWork()
        {
            Console.WriteLine($"Magazine '{Title}' has been closed.");
        }

        #endregion
    }
}