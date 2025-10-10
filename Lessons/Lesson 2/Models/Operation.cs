//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>01-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System;
using Lesson_2.Enums;

namespace Lesson_2.Models
{
    /// <summary>
    /// Represents a mathematical operation composed of operands and an operator.
    /// This class is <see cref="CLSCompliantAttribute"/> and can be used across all .NET languages.
    /// </summary>
    [CLSCompliant(true)]
    public class Operation
    {
        #region Public Properties
        /// <summary>
        /// Gets the value of the left operand.
        /// </summary>
        public double LeftOperand { get; }

        /// <summary>
        /// Gets the value of the right operand (if applicable).
        /// </summary>
        public double RightOperand { get; }

        /// <summary>
        /// Gets the operator associated with this operation.
        /// </summary>
        public Operator Operator { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class with two operands and an operator.
        /// </summary>
        /// <param name="left">The value of the left operand.</param>
        /// <param name="right">The value of the right operand.</param>
        /// <param name="operator">The operator to be applied.</param>
        public Operation(double left, double right, Operator op)
        {
            LeftOperand = left;
            RightOperand = right;
            Operator = op;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class with only one operand and an operator.
        /// This constructor can be used for unary operations (e.g., square root, negation).
        /// </summary>
        /// <param name="left">The value of the left operand.</param>
        /// <param name="op">The operator to be applied.</param>
        public Operation(double left, Operator op)
        {
            LeftOperand = left;
            Operator = op;
        }
        #endregion
    }
}
