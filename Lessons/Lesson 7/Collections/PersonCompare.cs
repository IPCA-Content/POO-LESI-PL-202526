//-----------------------------------------------------------------
//    <copyright file="PersonCompare.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>29-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Collections;
using Lesson_7.Models;

namespace Lesson_7.Collections
{
    /// <summary>
    /// Provides comparison logic for <see cref="Person"/> objects based on age and name.
    /// Implements the <see cref="IComparer"/> interface.
    /// </summary>
    [CLSCompliant(true)]
    public class PersonCompare : IComparer
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCompare"/> class.
        /// </summary>
        public PersonCompare() { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Compares two <see cref="Person"/> objects first by age, then by name.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer indicating the relative order:
        /// <list type="bullet">
        /// <item><description>&lt; 0 → x is less than y</description></item>
        /// <item><description>= 0 → x equals y</description></item>
        /// <item><description>&gt; 0 → x is greater than y</description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when either object is not of type <see cref="Person"/>.</exception>
        public int Compare(object? x, object? y)
        {
            // Handle null cases
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Ensure x and y are of type Person
            if (!(x is Person) || !(y is Person))
                throw new ArgumentException("Both objects must be of type Person");

            // Cast x and y to Person
            Person personX = (Person)x;
            Person personY = (Person)y;

            // Compare by age
            if (personX.age > personY.age) return 1;
            if (personX.age < personY.age) return -1;

            // If ages are equal, compare by name
            return string.Compare(personX.name, personY.name, StringComparison.InvariantCulture);
        }

        #endregion
    }
}