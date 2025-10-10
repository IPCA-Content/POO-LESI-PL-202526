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
    /// Represents a cat, derived from the <see cref="Animal"/> class.
    /// </summary>
    [CLSCompliant(true)]
    public class Cat : Animal
    {
        #region Properties

        /// <summary>
        /// Gets or sets the cat's eye color.
        /// </summary>
        public string EyeColor { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Cat"/> class.
        /// </summary>
        /// <param name="id">The cat's ID.</param>
        /// <param name="name">The cat's name.</param>
        /// <param name="age">The cat's age.</param>
        /// <param name="eyeColor">The cat's eye color.</param>
        public Cat(int id, string name, int age, string eyeColor)
            : base(id, name, age)
        {
            EyeColor = eyeColor;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Makes the cat walk.
        /// </summary>
        public override void Walk()
        {
            Console.WriteLine($"{Name} Walking");
        }
        
        /// <summary>
        /// Makes the cat eat.
        /// </summary>
        public override void Eat()
        {
            Console.WriteLine($"{Name} eating");
        }

        #endregion
    }
}
