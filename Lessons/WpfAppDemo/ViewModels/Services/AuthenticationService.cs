//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using WpfAppDemo.Models.Entities;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.ViewModels.Interfaces;

namespace WpfAppDemo.ViewModels.Services
{
    /// <summary>
    /// Provides authentication services to validate users.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="AuthenticationService"/> with a user repository.
        /// </summary>
        /// <param name="userRepository">Repository used to fetch user data.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="userRepository"/> is null.</exception>
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if a user with the specified username and password exists.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if a user exists and the password matches; otherwise, false.</returns>
        public bool UserExists(string username, string password)
        {
            // Return false if username or password is null or empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Retrieve user from repository
            User user = _userRepository.GetUserByUsername(username);

            // Return false if user is not found
            if (user == null)
            {
                return false;
            }

            // Validate password
            return user.Password == password;
        }

        #endregion
    }
}