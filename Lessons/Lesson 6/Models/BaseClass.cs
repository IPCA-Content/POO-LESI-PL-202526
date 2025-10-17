//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents a base class with a unique globally unique identifier (ID).
    /// </summary>
    [CLSCompliant(true)]
    public abstract class BaseClass
    {
        #region Properties

        /// <summary>
        /// Gets the unique ID of the instance.
        /// </summary>
        public Guid ID { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClass"/> class and generates a unique ID.
        /// </summary>
        protected BaseClass()
        {
            GenerateID();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a new globally unique ID for the instance.
        /// </summary>
        private void GenerateID()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}