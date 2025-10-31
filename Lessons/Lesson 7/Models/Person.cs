//-----------------------------------------------------------------
//    <copyright file="Person.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>29-10-2025</date>
//    <time>21:00</time>
//    <version>0.2</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_7.Models
{
    /// <summary>
    /// Represents a person with a name and age.
    /// Implements <see cref="IComparable"/> to support sorting and comparison.
    /// </summary>
    [CLSCompliant(true)]
    public class Person : IComparable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int age { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="_name">The name of the person.</param>
        /// <param name="_age">The age of the person.</param>
        public Person(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares the current <see cref="Person"/> object with another <see cref="Person"/>.
        /// The comparison is first made by <see cref="age"/>, then by <see cref="name"/> if ages are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// A signed integer that indicates the relative order of the objects being compared.
        /// <list type="bullet">
        /// <item><description>&lt; 0 → This instance precedes <paramref name="obj"/>.</description></item>
        /// <item><description>= 0 → This instance occurs in the same position as <paramref name="obj"/>.</description></item>
        /// <item><description>&gt; 0 → This instance follows <paramref name="obj"/>.</description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ApplicationException">Thrown if the object is not of type <see cref="Person"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (!(obj is Person other))
                throw new ApplicationException("Object must be of type Person");

            // First, compare by age
            int ageComparison = age.CompareTo(other.age);
            if (ageComparison != 0)
                return ageComparison;

            // If ages are equal, compare by name (alphabetically)
            return string.Compare(name, other.name, StringComparison.Ordinal);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor for the <see cref="Person"/> class.
        /// Used for cleanup before garbage collection.
        /// </summary>
        ~Person()
        {
            // Example: Close unmanaged resources (e.g., database connections)
            // connection.Close();
        }

        #endregion
    }
}
