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
    /// Represents a treatment composed of medication(s).
    /// </summary>
    [CLSCompliant(true)]
    public class Treatment : BaseClass
    {
        #region Private Fields

        private string _description;
        private readonly List<Medication> _medications;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the description of the treatment. Cannot be null, empty, or longer than 200 characters.
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Description cannot be null or empty.", nameof(Description));
                if (value.Length > 200)
                    throw new ArgumentException("Description cannot be longer than 200 characters.", nameof(Description));
                _description = value;
            }
        }

        /// <summary>
        /// Gets the list of medications included in the treatment.
        /// </summary>
        public List<Medication> Medications => new List<Medication>(_medications);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Treatment"/> class with a description.
        /// </summary>
        /// <param name="description">The description of the treatment.</param>
        public Treatment(string description)
        {
            Description = description;
            _medications = new List<Medication>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a medication to the treatment.
        /// </summary>
        /// <param name="medication">The medication to add. Cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown if medication is null.</exception>
        public void AddMedication(Medication medication)
        {
            if (medication == null)
                throw new ArgumentNullException(nameof(medication), "Medication cannot be null.");

            _medications.Add(medication);
        }

        /// <summary>
        /// Displays a summary of the treatment and all medications included.
        /// </summary>
        public void DisplayTreatment()
        {
            Console.WriteLine($"Treatment {ID}: {Description}");
            foreach (var m in _medications)
                Console.WriteLine($"  Medication {m.ID}: {m.Name}, Dosage: {m.Dosage}, Duration: {m.DurationDays} days");
        }

        #endregion
    }
}