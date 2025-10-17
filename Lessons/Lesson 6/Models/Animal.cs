//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents a pet (animal) with properties such as Name, Species, Breed, Age, and Owner.
    /// </summary>
    [CLSCompliant(true)]
    public class Animal : BaseClass
    {
        #region Private Fields

        private string _name;
        private string _species;
        private string _breed;
        private int _age;
        private Client _owner;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the animal. Cannot be null, empty, or longer than 100 characters.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));
                if (value.Length > 100)
                    throw new ArgumentException("Name cannot be longer than 100 characters.", nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the species of the animal (e.g., Dog, Cat). Cannot be null or empty.
        /// </summary>
        public string Species
        {
            get => _species;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Species cannot be null or whitespace.", nameof(Species));
                if (value.Length > 50)
                    throw new ArgumentException("Species cannot be longer than 50 characters.", nameof(Species));
                _species = value;
            }
        }

        /// <summary>
        /// Gets or sets the breed of the animal. Cannot be null or empty.
        /// </summary>
        public string Breed
        {
            get => _breed;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Breed cannot be null or whitespace.", nameof(Breed));
                if (value.Length > 50)
                    throw new ArgumentException("Breed cannot be longer than 50 characters.", nameof(Breed));
                _breed = value;
            }
        }

        /// <summary>
        /// Gets or sets the age of the animal. Must be non-negative.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age cannot be negative.", nameof(Age));
                _age = value;
            }
        }

        /// <summary>
        /// Gets or sets the owner of the animal (Client). Cannot be null.
        /// </summary>
        public Client Owner
        {
            get => _owner;
            set => _owner = value ?? throw new ArgumentNullException(nameof(Owner), "Owner cannot be null.");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Animal"/> class with specified properties.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="species">The species of the animal.</param>
        /// <param name="breed">The breed of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="owner">The owner of the animal.</param>
        public Animal(string name, string species, string breed, int age, Client owner)
        {
            Name = name;
            Species = species;
            Breed = breed;
            Age = age;
            Owner = owner;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the information of the animal.
        /// </summary>
        /// <param name="name">New name of the animal.</param>
        /// <param name="species">New species of the animal.</param>
        /// <param name="breed">New breed of the animal.</param>
        /// <param name="age">New age of the animal.</param>
        public void UpdateInfo(string name, string species, string breed, int age)
        {
            Name = name;
            Species = species;
            Breed = breed;
            Age = age;
        }

        /// <summary>
        /// Displays a summary of the animal, including ID, Name, Species, Breed, Age, and Owner.
        /// </summary>
        public void DisplaySummary()
        {
            Console.WriteLine($"Animal {ID}: {Name} ({Species} - {Breed}), Age: {Age}, Owner: {Owner?.FullName}");
        }

        #endregion
    }
}