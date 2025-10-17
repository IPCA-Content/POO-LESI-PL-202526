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
    /// Represents a student, derived from <see cref="User"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class Student : User
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        public Student(string name) 
            : base(name)
        {
        }

        #endregion
    }
}