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
    /// Represents a library that manages works and users.
    /// </summary>
    [CLSCompliant(true)]
    public class Library
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the library.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the library.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the contact information of the library.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets the daily work description.
        /// </summary>
        public string DailyWork { get; set; }

        /// <summary>
        /// Gets or sets the user currently associated with the library.
        /// </summary>
        public User User { get; set; }

        #endregion

        #region Fields

        /// <summary>
        /// Internal list of works in the library.
        /// </summary>
        private readonly List<Work> _works;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Library"/> class.
        /// </summary>
        /// <param name="name">The name of the library.</param>
        /// <param name="address">The address of the library.</param>
        /// <param name="contact">The contact information of the library.</param>
        /// <param name="user">The initial user associated with the library.</param>
        public Library(string name, string address, string contact, User user)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            User = user ?? throw new ArgumentNullException(nameof(user));

            _works = new List<Work>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers a work in the library.
        /// </summary>
        /// <param name="work">The work to add.</param>
        public void RegisterWork(Work work)
        {
            if (work == null)
                throw new ArgumentNullException(nameof(work), "Work cannot be null.");

            _works.Add(work);
        }

        /// <summary>
        /// Updates the library user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public void RegisterUser(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        /// <summary>
        /// Finds a work by title.
        /// </summary>
        /// <param name="title">The title of the work.</param>
        /// <returns>The work if found; otherwise, null.</returns>
        public Work? GetWork(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));

            return _works.Find(w => w.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns the daily work description.
        /// </summary>
        /// <returns>The daily work string.</returns>
        public string? GetDailyWork()
        {
            return DailyWork;
        }

        #endregion
    }
}