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
    /// Represents a car, derived from the <see cref="Vehicle"/> class.
    /// </summary>
    [CLSCompliant(true)]
    public class Car : Vehicle
    {
        #region Properties

        /// <summary>
        /// Gets or sets the number of doors in the car.
        /// </summary>
        public int NumberOfDoors { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class.
        /// </summary>
        /// <param name="plate">The car's licence plate.</param>
        /// <param name="color">The car's color.</param>
        /// <param name="brand">The car's brand.</param>
        /// <param name="model">The car's model.</param>
        /// <param name="numberOfDoors">The number of doors in the car.</param>
        public Car(string plate, string color, string brand, string model, int numberOfDoors)
            : base(plate, color, brand, model)
        {
            NumberOfDoors = numberOfDoors;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Starts the car.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Car Start");
        }

        /// <summary>
        /// Stops the car.
        /// </summary>
        public override void Stop()
        {
            Console.WriteLine("Car Stop");
        }

        /// <summary>
        /// Displays information about the car, including the number of doors.
        /// </summary>
        public override void Display()
        {
            Console.WriteLine($"Licence Plate: {LicencePlate}, Color: {Color}, Brand: {Brand}, Model: {Model}, Number of Doors: {NumberOfDoors}");
        }

        #endregion
    }
}