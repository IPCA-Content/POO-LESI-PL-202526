//-----------------------------------------------------------------
//    <copyright file="Person.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>05-10-2025</date>
//    <time>21:00</time>
//    <version>0.2</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

[assembly: CLSCompliant(true)]

namespace Lesson_8
{
    /// <summary>
    /// Represents a person with a name, age, and a non-serialized profile value.
    /// </summary>
    [Serializable]
    public class Person
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }

        #endregion

        #region Non-Serialized Fields

        /// <summary>
        /// A profile identifier that is not serialized.
        /// </summary>
        [NonSerialized]
        public int Profile;

        #endregion
    }
}