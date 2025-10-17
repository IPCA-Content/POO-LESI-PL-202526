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
    /// Represents a simple reusable generic repository for in-memory storage of items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the repository.</typeparam>
    [CLSCompliant(true)]
    public class Repository<T>
    {
        #region Fields

        /// <summary>
        /// Internal list that holds the repository items.
        /// </summary>
        private readonly List<T> _items = new();

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new item to the repository.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            if (item == null) 
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");

            _items.Add(item);
        }

        /// <summary>
        /// Removes an item from the repository.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if the item was successfully removed; otherwise, false.</returns>
        public bool Remove(T item)
        {
            if (item == null) 
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");

            return _items.Remove(item);
        }

        /// <summary>
        /// Retrieves all items from the repository.
        /// </summary>
        /// <returns>A new list containing all items.</returns>
        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        /// <summary>
        /// Finds the first item that matches the given condition.
        /// </summary>
        /// <param name="condition">A predicate to test items.</param>
        /// <returns>The first item that matches the condition, or null if none found.</returns>
        public T? Find(Func<T, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition), "Condition cannot be null.");

            return _items.FirstOrDefault(condition);
        }

        /// <summary>
        /// Gets the total number of items in the repository.
        /// </summary>
        /// <returns>The number of items stored.</returns>
        public int Count()
        {
            return _items.Count;
        }

        #endregion
    }
}