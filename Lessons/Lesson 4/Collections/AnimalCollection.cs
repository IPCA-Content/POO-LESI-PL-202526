//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>09-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_4.Models;

/// <summary>
/// Represents cats, derived from the <see cref="Cat"/> class.
/// </summary>
[CLSCompliant(true)]
public class AnimalCollection<T> where T : Animal
{
    #region Private properties
    
    /// <summary>
    /// Animal list
    /// </summary>
    private readonly List<T> _animal;
    #endregion

    #region Constructors
    
    /// <summary>
    /// Cats Constructor instanciate _cats
    /// </summary>
    public AnimalCollection()
    {
        _animal = new List<T>();
    }
    #endregion

    #region Public Methods

    /// <summary>
    /// Add one cat to the list
    /// </summary>
    /// <param name="cat"></param>
    public void Add(T animal)
    {
        _animal.Add(animal);
    }

    public bool Update(T animal)
    {
        T existing = _animal.Find(a => a.ID == animal.ID);
        if (existing == null)
            return false;

        // Example update (manually copy relevant fields)
        existing.Name = animal.Name;
        existing.Age = animal.Age;
    
        return true;
    }

    /// <summary>
    /// Delete cat from list
    /// </summary>
    /// <param name="cat"></param>
    /// <returns></returns>
    public bool Del(T cat)
    {
        if(_animal.Contains(cat)) 
            return _animal.Remove(cat);
        return false;
    }

    /// <summary>
    /// Get Cat by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? GetById(int id)
    {
        // Option 1: with foreach
        // foreach (Cat cat in _cats)
        // {
        //     if (cat.ID == id) return cat;
        // }
        
        // Option 2: with for loop
        // int counter = _cats.Count;
        // for (int i = 0; i < counter; i++)
        // {
        //     if (_cats[i].ID == id); return _cats[i];
        // }
        
        // Option 3: Find() is a built-in LINQ-style method
        return _animal.Find(a => a.ID == id);;
    }

    /// <summary>
    /// Filter cats list by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<T> Filter(string name)
    {
        return _animal.FindAll(a => a.Name == name);
    }

    /// <summary>
    /// Display details for all 
    /// </summary>
    public void DisplayAll()
    {
        foreach (T cat in _animal)
        {
            cat.Display();
        }
    }

    /// <summary>
    /// Clear all from list
    /// </summary>
    public void Clear()
    {
        _animal.Clear();
    }
    
    #endregion
}