//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>08-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_2
{
    /// <summary>
    /// Represents an abstract vehicle with basic properties and behaviors.
    /// </summary>
    [CLSCompliant(true)]
    public abstract class Vehicle
    {
        #region Properties

        /// <summary>
        /// Gets or sets the vehicle's licence plate.
        /// </summary>
        public string LicencePlate { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's model.
        /// </summary>
        public string Model { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="plate">The vehicle licence plate.</param>
        /// <param name="color">The vehicle color.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        public Vehicle(string plate, string color, string brand, string model)
        {
            LicencePlate = plate;
            Color = color;
            Brand = brand;
            Model = model;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Starts the vehicle.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Stops the vehicle.
        /// </summary>
        public abstract void Stop();

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Displays basic vehicle information.
        /// </summary>
        public virtual void Display()
        {
            Console.WriteLine($"Licence Plate: {LicencePlate}, Color: {Color}, Brand: {Brand}, Model: {Model}");
        }

        #endregion
    }
}
