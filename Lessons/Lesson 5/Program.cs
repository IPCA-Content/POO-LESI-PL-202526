
//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_5.Collections;
using Lesson_5.Models;

//-------------------------------------------------------------
// Create sample newspapers
//-------------------------------------------------------------
NewsPaper newspaper1 = new NewsPaper("Daily Times", "John Smith", "EN", "Print", "Daily Publisher", 2025, 1);
NewsPaper newspaper2 = new NewsPaper("Morning Herald", "Jane Doe", "EN", "Print", "Herald Publisher", 2025, 2);
NewsPaper newspaper3 = new NewsPaper("Evening Post", "Robert Brown", "EN", "Print", "Post Publisher", 2025, 3);

// Create a collection of works for newspapers
WorkCollection<Work> newspaperCollection = new WorkCollection<Work>();
newspaperCollection.Add(newspaper1);
newspaperCollection.Add(newspaper2);
newspaperCollection.Add(newspaper3);

// Display newspapers
Console.WriteLine("=== Newspapers Collection ===");
newspaperCollection.Display();

//-------------------------------------------------------------
// Create sample magazines
//-------------------------------------------------------------
Magazine magazine1 = new Magazine("Science Today", "Alice Green", "EN", "Digital", "Science Publisher", 2025, 101);
Magazine magazine2 = new Magazine("Tech Monthly", "Brian White", "EN", "Digital", "Tech Publisher", 2025, 102);
Magazine magazine3 = new Magazine("Health Weekly", "Catherine Black", "EN", "Digital", "Health Publisher", 2025, 103);

// Create a collection of works for magazines
WorkCollection<Work> magazineCollection = new WorkCollection<Work>();
magazineCollection.Add(magazine1);
magazineCollection.Add(magazine2);
magazineCollection.Add(magazine3);

// Display magazines
Console.WriteLine("\n=== Magazines Collection ===");
magazineCollection.Display();

//-------------------------------------------------------------
// Create sample libraries with different user types
//-------------------------------------------------------------
Library teacherLibrary = new Library("Central Library", "123 Library St", "contact@library.com", new Teacher("Dr. Emma Watson", "Mathematics"));
Library employeeLibrary = new Library("City Library", "456 Main St", "info@citylibrary.com", new Employee("Mark Johnson", "Librarian"));
Library studentLibrary = new Library("Campus Library", "789 College Ave", "student@campus.com", new Student("Sophia Lee"));

// Display some basic info
Console.WriteLine("\n=== Libraries Info ===");
Console.WriteLine($"Teacher Library: {teacherLibrary.Name}, Managed by: {teacherLibrary.User.Name}");
Console.WriteLine($"Employee Library: {employeeLibrary.Name}, Managed by: {employeeLibrary.User.Name}");
Console.WriteLine($"Student Library: {studentLibrary.Name}, Managed by: {studentLibrary.User.Name}");