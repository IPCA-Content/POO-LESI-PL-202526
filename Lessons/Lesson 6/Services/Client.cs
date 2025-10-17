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
    /// Represents a client (owner of animals) with full name, phone number, email, and a list of animals.
    /// </summary>
    [CLSCompliant(true)]
    public class Client : BaseClass
    {
        #region Private Fields

        private string _fullName;
        private string _phoneNumber;
        private string _email;
        private readonly List<Animal> _animals;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the full name of the client. Cannot be null or empty.
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be null or empty.", nameof(FullName));
                if (value.Length > 100)
                    throw new ArgumentException("Full name cannot be longer than 100 characters.", nameof(FullName));
                _fullName = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone number of the client. Cannot be null or empty.
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone number cannot be null or empty.", nameof(PhoneNumber));
                if (value.Length > 20)
                    throw new ArgumentException("Phone number cannot be longer than 20 characters.", nameof(PhoneNumber));
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address of the client. Cannot be null or empty.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be null or empty.", nameof(Email));
                if (value.Length > 100)
                    throw new ArgumentException("Email cannot be longer than 100 characters.", nameof(Email));
                _email = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class with specified full name, phone number, and email.
        /// </summary>
        /// <param name="fullName">Full name of the client.</param>
        /// <param name="phoneNumber">Phone number of the client.</param>
        /// <param name="email">Email address of the client.</param>
        public Client(string fullName, string phoneNumber, string email)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            _animals = new List<Animal>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an animal to the client's list of animals and sets this client as the owner.
        /// </summary>
        /// <param name="animal">The animal to add. Cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown if the animal is null.</exception>
        public void AddAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");

            animal.Owner = this;
            _animals.Add(animal);
        }

        /// <summary>
        /// Gets a copy of the list of animals owned by the client.
        /// </summary>
        /// <returns>A list of <see cref="Animal"/> objects.</returns>
        public List<Animal> GetAnimals()
        {
            return new List<Animal>(_animals);
        }

        /// <summary>
        /// Displays a summary of the client and all owned animals.
        /// </summary>
        public void DisplayAnimals()
        {
            Console.WriteLine($"Client {ID}: {FullName} - Animals:");
            foreach (var a in _animals)
                a.DisplaySummary();
        }

        #endregion
    }
}