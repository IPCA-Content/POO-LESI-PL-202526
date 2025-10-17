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
    /// Represents a base user with an ID and a name.
    /// </summary>
    [CLSCompliant(true)]
    public abstract class User
    {
        #region Properties

        /// <summary>
        /// Gets the unique ID of the user.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        protected User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            GenerateID();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a new globally unique ID for the user.
        /// </summary>
        private void GenerateID()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}
