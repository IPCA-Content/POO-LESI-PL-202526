//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>22-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace DatesUtilities.Interfaces;

/// <summary>
/// Date Provider
/// </summary>
public interface IDateProvider
{
    /// <summary>
    /// Date Only property
    /// </summary>
    DateOnly Today { get; }
}