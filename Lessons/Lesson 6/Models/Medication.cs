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
    /// Represents a medication used in a treatment, with properties such as Name, Dosage, and Duration.
    /// </summary>
    [CLSCompliant(true)]
    public class Medication : BaseClass
    {
        #region Private Fields

        private string _name;
        private string _dosage;
        private int _durationDays;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the medication. Cannot be null, empty, or longer than 100 characters.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Medication name cannot be null or empty.", nameof(Name));
                if (value.Length > 100)
                    throw new ArgumentException("Medication name cannot be longer than 100 characters.", nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the dosage information (e.g., "500mg twice a day"). Cannot be null or empty.
        /// </summary>
        public string Dosage
        {
            get => _dosage;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Dosage cannot be null or empty.", nameof(Dosage));
                if (value.Length > 100)
                    throw new ArgumentException("Dosage cannot be longer than 100 characters.", nameof(Dosage));
                _dosage = value;
            }
        }

        /// <summary>
        /// Gets or sets the duration of the treatment in days. Must be non-negative.
        /// </summary>
        public int DurationDays
        {
            get => _durationDays;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Duration cannot be negative.", nameof(DurationDays));
                _durationDays = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Medication"/> class with specified properties.
        /// </summary>
        /// <param name="name">The name of the medication.</param>
        /// <param name="dosage">The dosage of the medication.</param>
        /// <param name="durationDays">The duration of the treatment in days.</param>
        public Medication(string name, string dosage, int durationDays)
        {
            Name = name;
            Dosage = dosage;
            DurationDays = durationDays;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays a summary of the medication, including ID, Name, Dosage, and Duration.
        /// </summary>
        public void DisplaySummary()
        {
            Console.WriteLine($"Medication {ID}: {Name}, Dosage: {Dosage}, Duration: {DurationDays} days");
        }

        #endregion
    }
}