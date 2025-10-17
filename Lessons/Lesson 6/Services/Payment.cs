//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_6.Enums;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents a payment for an appointment, including amount, method, and payment date.
    /// </summary>
    [CLSCompliant(true)]
    public class Payment : BaseClass
    {
        #region Private Fields

        private Appointment _appointment;
        private PaymentMethod _method;
        private decimal _amount;
        private DateTime _paymentDate;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the appointment associated with this payment. Cannot be null.
        /// </summary>
        public Appointment Appointment
        {
            get => _appointment;
            set => _appointment = value ?? throw new ArgumentNullException(nameof(Appointment), "Appointment cannot be null.");
        }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        public PaymentMethod Method
        {
            get => _method;
            set => _method = value;
        }

        /// <summary>
        /// Gets or sets the amount of the payment. Must be greater than zero.
        /// </summary>
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Amount must be greater than zero.", nameof(Amount));
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the date of the payment. Cannot be in the future.
        /// </summary>
        public DateTime PaymentDate
        {
            get => _paymentDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Payment date cannot be in the future.", nameof(PaymentDate));
                _paymentDate = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="appointment">The appointment for which the payment is made.</param>
        /// <param name="method">The payment method.</param>
        /// <param name="amount">The payment amount.</param>
        /// <param name="paymentDate">The date of the payment.</param>
        public Payment(Appointment appointment, PaymentMethod method, decimal amount, DateTime paymentDate)
        {
            Appointment = appointment;
            Method = method;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the payment, displaying details. In a real system, this would interact with a payment gateway and persist the transaction.
        /// </summary>
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing payment {ID} - Appointment {Appointment?.ID}, Method: {Method}, Amount: {Amount:C}");
            // Real system: call payment gateway, persist transaction, issue receipt...
        }

        #endregion
    }
}