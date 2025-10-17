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
    /// Represents an employee, derived from <see cref="User"/>.
    /// </summary>
    [CLSCompliant(true)]
    public class Employee : User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the job title of the employee.
        /// </summary>
        public string Job { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="job">The job title of the employee.</param>
        public Employee(string name, string job) 
            : base(name)
        {
            Job = job ?? throw new ArgumentNullException(nameof(job), "Job cannot be null.");
        }

        #endregion
    }
}