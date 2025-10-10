//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>09-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_4.Models
{
    /// <summary>
    /// Represents a dog, derived from the <see cref="Animal"/> class.
    /// </summary>
    [CLSCompliant(true)]
    public class Dog : Animal
    {
        #region Properties

        /// <summary>
        /// Gets or sets the dog's hair color.
        /// </summary>
        public string HairColor { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Dog"/> class.
        /// </summary>
        /// <param name="id">The dog's ID.</param>
        /// <param name="name">The dog's name.</param>
        /// <param name="age">The dog's age.</param>
        /// <param name="hairColor">The dog's hair color.</param>
        public Dog(int id, string name, int age, string hairColor)
            : base(id, name, age)
        {
            HairColor = hairColor;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Makes the dog walk.
        /// </summary>
        public override void Walk()
        {
            Console.WriteLine($"{Name} Walking...");
        }

        #endregion
    }
}
