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
    /// Represents a teacher, derived from <see cref="User"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class Teacher : User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discipline/subject taught by the teacher.
        /// </summary>
        public string Discipline { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Teacher"/> class.
        /// </summary>
        /// <param name="name">The name of the teacher.</param>
        /// <param name="discipline">The discipline/subject of the teacher.</param>
        public Teacher(string name, string discipline)
            : base(name)
        {
            Discipline = discipline ?? throw new ArgumentNullException(nameof(discipline), "Discipline cannot be null.");
        }

        #endregion
    }
}