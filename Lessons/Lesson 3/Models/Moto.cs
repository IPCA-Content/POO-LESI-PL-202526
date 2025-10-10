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
    /// Represents a motorcycle, derived from the <see cref="Vehicle"/> class.
    /// </summary>
    [CLSCompliant(true)]
    public class Moto : Vehicle
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the motorcycle has a sidecar.
        /// </summary>
        public bool ContainsSideCar { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Moto"/> class.
        /// </summary>
        /// <param name="plate">The motorcycle's licence plate.</param>
        /// <param name="color">The motorcycle's color.</param>
        /// <param name="brand">The motorcycle's brand.</param>
        /// <param name="model">The motorcycle's model.</param>
        /// <param name="sidecar">Indicates whether the motorcycle includes a sidecar.</param>
        public Moto(string plate, string color, string brand, string model, bool sidecar)
            : base(plate, color, brand, model)
        {
            ContainsSideCar = sidecar;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Starts the motorcycle.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Moto Start");
        }

        /// <summary>
        /// Stops the motorcycle.
        /// </summary>
        public override void Stop()
        {
            Console.WriteLine("Moto Stop");
        }

        /// <summary>
        /// Displays information about the motorcycle, including sidecar presence.
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Side Car: {ContainsSideCar}");
        }

        #endregion
    }
}
