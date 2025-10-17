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
    /// Represents a veterinarian with full name, specialty, license number, and a list of appointments.
    /// </summary>
    [CLSCompliant(true)]
    public class Veterinarian : BaseClass
    {
        #region Private Fields

        private string _fullName;
        private string _specialty;
        private string _licenseNumber;
        private readonly List<Appointment> _appointments;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the full name of the veterinarian. Cannot be null or empty.
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
        /// Gets or sets the specialty of the veterinarian (e.g., Surgery, Dermatology). Cannot be null or empty.
        /// </summary>
        public string Specialty
        {
            get => _specialty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Specialty cannot be null or empty.", nameof(Specialty));
                if (value.Length > 50)
                    throw new ArgumentException("Specialty cannot be longer than 50 characters.", nameof(Specialty));
                _specialty = value;
            }
        }

        /// <summary>
        /// Gets or sets the license number of the veterinarian. Cannot be null or empty.
        /// </summary>
        public string LicenseNumber
        {
            get => _licenseNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("License number cannot be null or empty.", nameof(LicenseNumber));
                if (value.Length > 50)
                    throw new ArgumentException("License number cannot be longer than 50 characters.", nameof(LicenseNumber));
                _licenseNumber = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Veterinarian"/> class with the specified properties.
        /// </summary>
        /// <param name="fullName">Full name of the veterinarian.</param>
        /// <param name="specialty">Specialty of the veterinarian.</param>
        /// <param name="licenseNumber">License number of the veterinarian.</param>
        public Veterinarian(string fullName, string specialty, string licenseNumber)
        {
            FullName = fullName;
            Specialty = specialty;
            LicenseNumber = licenseNumber;
            _appointments = new List<Appointment>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lists all appointments of the veterinarian.
        /// </summary>
        public void ListAppointments()
        {
            Console.WriteLine($"Vet {FullName} appointments:");
            foreach (var appt in _appointments)
                Console.WriteLine($"  {appt.ID} - {appt.Date} - Animal: {appt.Animal?.Name} - Cancelled: {appt.IsCancelled}");
        }

        /// <summary>
        /// Conducts a specified appointment if it is not cancelled.
        /// </summary>
        /// <param name="appointment">The appointment to conduct.</param>
        public void ConductAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");
            
            if (appointment.IsCancelled)
            {
                Console.WriteLine("Cannot conduct a cancelled appointment.");
                return;
            }

            Console.WriteLine($"Conducting appointment {appointment.ID} for {appointment.Animal?.Name} by {FullName}");
            // realistic logic would go here (diagnose, add treatments, etc.)
        }

        /// <summary>
        /// Adds an appointment to the veterinarian's schedule.
        /// </summary>
        /// <param name="appointment">The appointment to add. Cannot be null.</param>
        internal void AddAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");

            _appointments.Add(appointment);
        }

        /// <summary>
        /// Returns a copy of the list of appointments for the veterinarian.
        /// </summary>
        /// <returns>A list of <see cref="Appointment"/> objects.</returns>
        public List<Appointment> GetAppointments()
        {
            return new List<Appointment>(_appointments);
        }

        #endregion
    }
}
