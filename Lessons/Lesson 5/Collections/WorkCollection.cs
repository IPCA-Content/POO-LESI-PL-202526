//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_5.Models;

namespace Lesson_5.Collections
{
    /// <summary>
    /// Represents a collection of <see cref="Work"/> objects with basic operations.
    /// </summary>
    /// <typeparam name="T">The type of work, must inherit from <see cref="Work"/>.</typeparam>
    [CLSCompliant(true)]
    public class WorkCollection<T> where T : Work
    {
        #region Fields

        /// <summary>
        /// The internal list that stores the works.
        /// </summary>
        private List<T> _works;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkCollection{T}"/> class.
        /// </summary>
        public WorkCollection()
        {
            _works = new List<T>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a work to the collection.
        /// </summary>
        /// <param name="work">The work to add.</param>
        public void Add(T work)
        {
            if (work == null)
                throw new ArgumentNullException(nameof(work), "Work cannot be null.");

            _works.Add(work);
        }

        /// <summary>
        /// Removes a work from the collection.
        /// </summary>
        /// <param name="work">The work to remove.</param>
        /// <returns>True if the work was successfully removed; otherwise, false.</returns>
        public bool Remove(T work)
        {
            if (work == null)
                throw new ArgumentNullException(nameof(work), "Work cannot be null.");

            return _works.Remove(work);
        }

        /// <summary>
        /// Displays all works in the collection to the console.
        /// </summary>
        public void Display()
        {
            if (_works.Count == 0)
            {
                Console.WriteLine("No works in the collection.");
                return;
            }

            foreach (var work in _works)
            {
                Console.WriteLine($"Title: {work.Title}, Author: {work.Author}");
            }
        }

        /// <summary>
        /// Clears all works from the collection.
        /// </summary>
        public void Clear()
        {
            _works.Clear();
        }

        #endregion
    }
}