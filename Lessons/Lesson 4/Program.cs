//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>09-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_4.Models;

Cat cat = new Cat(1, "abc", 10, "Green");
Cat cat1 = new Cat(2, "abd", 5, "Green");
cat.Walk();
cat.Eat();

Dog dog = new Dog(1, "bbg", 10, "Brown");
dog.Walk();

Cats cats = new Cats();

cats.Add(cat);
cats.Add(cat1);

Cat returned = cats.GetById(1);
returned.Eat();

cats.DisplayAll();