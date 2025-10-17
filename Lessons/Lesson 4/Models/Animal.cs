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
    /// Represents an abstract animal with basic properties and behaviors.
    /// </summary>
    [CLSCompliant(true)]
    public abstract class Animal
    {
        #region Properties

        /// <summary>
        /// Gets or sets the animal's unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the animal's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the animal's age.
        /// </summary>
        public int Age { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Animal"/> class.
        /// </summary>
        /// <param name="id">The animal's ID.</param>
        /// <param name="name">The animal's name.</param>
        /// <param name="age">The animal's age.</param>
        public Animal(int id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Abstract method to make the animal walk.
        /// </summary>
        public abstract void Walk();

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Makes the animal eat.
        /// </summary>
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} Eating...");
        }

        /// <summary>
        /// Display name details
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"{Name} Displaying");
        }
        
        #endregion
    }
}
