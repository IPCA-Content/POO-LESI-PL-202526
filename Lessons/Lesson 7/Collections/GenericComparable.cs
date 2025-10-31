//-----------------------------------------------------------------
//    <copyright file="GenericComparable.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>29-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Reflection;

namespace Lesson_7.Collections
{
    /// <summary>
    /// A generic comparer that compares two objects of type <typeparamref name="T"/>
    /// based on a specified property name using reflection.
    /// </summary>
    /// <typeparam name="T">The type of objects being compared.</typeparam>
    [CLSCompliant(true)]
    public class GenericComparable<T> : IComparer<T>
    {
        #region Private Fields

        /// <summary>
        /// The name of the property used for comparison.
        /// </summary>
        private readonly string _propertyName;

        /// <summary>
        /// Determines whether the comparison is in ascending or descending order.
        /// </summary>
        private readonly bool _ascending;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericComparable{T}"/> class.
        /// </summary>
        /// <param name="propertyName">The property name used for comparison.</param>
        /// <param name="ascending">Specifies whether sorting is ascending (true) or descending (false).</param>
        public GenericComparable(string propertyName, bool ascending = true)
        {
            _propertyName = propertyName;
            _ascending = ascending;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Compares two objects of type <typeparamref name="T"/> based on the specified property.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of x and y:
        /// less than zero if x &lt; y, zero if x = y, and greater than zero if x &gt; y.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the specified property does not exist.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the property does not implement IComparable.</exception>
        public int Compare(T? x, T? y)
        {
            // Handle null cases
            if (x == null && y == null) return 0;
            if (x == null) return _ascending ? -1 : 1;
            if (y == null) return _ascending ? 1 : -1;

            // Retrieve property using reflection
            PropertyInfo? property = typeof(T).GetProperty(_propertyName);
            if (property == null)
                throw new ArgumentException($"Property '{_propertyName}' not found on type {typeof(T).Name}");

            object? valueX = property.GetValue(x);
            object? valueY = property.GetValue(y);

            // Handle null property values
            if (valueX == null && valueY == null) return 0;
            if (valueX == null) return _ascending ? -1 : 1;
            if (valueY == null) return _ascending ? 1 : -1;

            // Compare using IComparable
            if (valueX is IComparable comparableX)
            {
                int result = comparableX.CompareTo(valueY);
                return _ascending ? result : -result;
            }

            throw new InvalidOperationException($"Property '{_propertyName}' does not implement IComparable.");
        }

        #endregion
    }
} 