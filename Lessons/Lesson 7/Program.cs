//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>29-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using Lesson_7;
using Lesson_7.Collections;
using Lesson_7.Models;

[assembly: CLSCompliant(true)]

#region Main
/// <summary>
/// Demonstrates sorting, comparison, and exception handling
/// using custom classes and comparers.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    private static void Main()
    {
        #region ArrayList with IComparable (Person)
        Console.WriteLine($"=== ArrayList with IComparable ==={Environment.NewLine}");

        ArrayList arrayList = new ArrayList
        {
            new Person("Martins", 22),
            new Person("Helder", 20),
            new Person("Joaquim", 21),
            new Person("Matias", 19)
        };

        Console.WriteLine($"Before Sorted array list:{Environment.NewLine}");
        foreach (Person person in arrayList)
            Console.WriteLine($"Name: {person.name}, Age: {person.age}");

        arrayList.Sort();

        Console.WriteLine($"{Environment.NewLine}After Sorted array list:{Environment.NewLine}");
        foreach (Person person in arrayList)
            Console.WriteLine($"Name: {person.name}, Age: {person.age}");
        #endregion

        #region ArrayList with Custom IComparer (PersonCompare)
        Console.WriteLine($"{Environment.NewLine}=== ArrayList with IComparer (PersonCompare) ==={Environment.NewLine}");

        ArrayList arrayList2 = new ArrayList
        {
            new Person("Ana", 22),
            new Person("Joana", 20),
            new Person("Sousa", 21),
            new Person("Esteves", 19)
        };

        Console.WriteLine($"Before Sorted array list:{Environment.NewLine}");
        foreach (Person person in arrayList2)
            Console.WriteLine(person.name);

        arrayList2.Sort(new PersonCompare());

        Console.WriteLine($"{Environment.NewLine}After Sorted array list:{Environment.NewLine}");
        foreach (Person person in arrayList2)
            Console.WriteLine(person.name);
        #endregion

        #region GenericComparable Demonstration
        Console.WriteLine($"{Environment.NewLine}=== List<T> with GenericComparable ==={Environment.NewLine}");

        List<Person> people = new List<Person>
        {
            new("Alice", 30),
            new("Bob", 25),
            new("Charlie", 30)
        };

        Console.WriteLine($"Before Sorted list:{Environment.NewLine}");
        foreach (Person person in people)
            Console.WriteLine($"Name: {person.name}, Age: {person.age}");

        // Sort by age ascending
        people.Sort(new GenericComparable<Person>("age"));
        Console.WriteLine($"{Environment.NewLine}After Sorted list by age:{Environment.NewLine}");
        foreach (Person person in people)
            Console.WriteLine($"Name: {person.name}, Age: {person.age}");

        // Sort by name descending
        people.Sort(new GenericComparable<Person>("name", ascending: false));
        Console.WriteLine($"{Environment.NewLine}After Sorted list by name descending:{Environment.NewLine}");
        foreach (Person person in people)
            Console.WriteLine($"Name: {person.name}, Age: {person.age}");
        Console.WriteLine($"{Environment.NewLine}End of program.{Environment.NewLine}");
        #endregion
        
        #region Exception Handling Demonstration
        try
        {
            // Simulate I/O, DB operations, etc
            throw new CustomException("Custom test exception triggered.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"IO Exception: {e.Message}");
            throw;
        }
        catch (SqlNullValueException e)
        {
            Console.WriteLine($"SQL Null Exception: {e.Message}");
            throw;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Divide by zero exception occurred.");
            throw;
        }
        catch (CustomException e)
        {
            Console.WriteLine($"Custom Exception: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine($"General Exception: {e.Message}");
            throw;
        }
        finally
        {
            // Example: cleanup logic such as connection.Close();
            Console.WriteLine("Cleanup complete (finally block executed).");
        }
        #endregion
    }
}
#endregion
