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
    /// Represents an appointment (consultation) between an animal and a veterinarian.
    /// </summary>
    [CLSCompliant(true)]
    public class Appointment : BaseClass
    {
        #region Private Fields

        private Animal _animal;
        private Veterinarian _veterinarian;
        private DateTime _date;
        private string _diagnosis;
        private readonly List<Treatment> _treatments;
        private bool _isCancelled;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the animal for the appointment. Cannot be null.
        /// </summary>
        public Animal Animal
        {
            get => _animal;
            set => _animal = value ?? throw new ArgumentNullException(nameof(Animal), "Animal cannot be null.");
        }

        /// <summary>
        /// Gets or sets the veterinarian for the appointment. Cannot be null.
        /// </summary>
        public Veterinarian Veterinarian
        {
            get => _veterinarian;
            set
            {
                _veterinarian = value ?? throw new ArgumentNullException(nameof(Veterinarian), "Veterinarian cannot be null.");
                _veterinarian.AddAppointment(this);
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the appointment. Must be in the future.
        /// </summary>
        public DateTime Date
        {
            get => _date;
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Appointment date cannot be in the past.", nameof(Date));
                _date = value;
            }
        }

        /// <summary>
        /// Gets or sets the diagnosis for the appointment. Can be empty but not null.
        /// </summary>
        public string Diagnosis
        {
            get => _diagnosis;
            set => _diagnosis = value ?? string.Empty;
        }

        /// <summary>
        /// Gets a read-only list of treatments associated with this appointment.
        /// </summary>
        public List<Treatment> Treatments => new List<Treatment>(_treatments);

        /// <summary>
        /// Gets a value indicating whether the appointment has been cancelled.
        /// </summary>
        public bool IsCancelled => _isCancelled;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Appointment"/> class.
        /// </summary>
        /// <param name="animal">The animal for the appointment.</param>
        /// <param name="veterinarian">The veterinarian for the appointment.</param>
        /// <param name="date">The date and time of the appointment.</param>
        /// <param name="diagnosis">Optional initial diagnosis.</param>
        public Appointment(Animal animal, Veterinarian veterinarian, DateTime date, string diagnosis = "")
        {
            _treatments = new List<Treatment>();
            Animal = animal;
            Veterinarian = veterinarian;
            Date = date;
            Diagnosis = diagnosis;
            _isCancelled = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a treatment to this appointment.
        /// </summary>
        /// <param name="treatment">The treatment to add. Cannot be null.</param>
        public void AddTreatment(Treatment treatment)
        {
            if (treatment == null)
                throw new ArgumentNullException(nameof(treatment), "Treatment cannot be null.");

            _treatments.Add(treatment);
        }

        /// <summary>
        /// Cancels the appointment.
        /// </summary>
        public void Cancel()
        {
            _isCancelled = true;
            Console.WriteLine($"Appointment {ID} cancelled.");
        }

        /// <summary>
        /// Displays details of the appointment, including animal, veterinarian, diagnosis, and treatments.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine($"Appointment {ID}: Date {Date}, Animal: {Animal?.Name}, Vet: {Veterinarian?.FullName}, Diagnosis: {Diagnosis}");
            Console.WriteLine("Treatments:");
            foreach (var t in _treatments)
                t.DisplayTreatment();
        }

        #endregion
    }
}