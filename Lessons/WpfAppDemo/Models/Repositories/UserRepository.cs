//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.IO;
using System.Text.Json;
using WpfAppDemo.Models.Entities;
using WpfAppDemo.Models.Repositories.Interfaces;

namespace WpfAppDemo.Models.Repositories
{
    /// <summary>
    /// Provides methods to access <see cref="User"/> entities from a JSON data store.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");
        private readonly string _usersFile;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        public UserRepository()
        {
            _usersFile = Path.Combine(_basePath, "users.json");

            // Ensure the file exists to avoid null or file not found issues
            if (!File.Exists(_usersFile))
            {
                File.WriteAllText(_usersFile, "[]"); // Initialize with empty JSON array
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a <see cref="User"/> by username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, <c>null</c>.</returns>
        public User? GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            List<User> users = LoadUsers();
            return users.FirstOrDefault(x => x.Username == username);
        }

        /// <summary>
        /// Loads the users from the JSON file.
        /// </summary>
        /// <returns>A list of <see cref="User"/> entities.</returns>
        private List<User> LoadUsers()
        {
            try
            {
                string readJsonString = File.ReadAllText(_usersFile);
                return JsonSerializer.Deserialize<List<User>>(readJsonString) ?? new List<User>();
            }
            catch (IOException)
            {
                // Log exception if needed
                return new List<User>();
            }
            catch (Exception)
            {
                // Log exception if needed
                return new List<User>();
            }
        }

        #endregion
    }
}
