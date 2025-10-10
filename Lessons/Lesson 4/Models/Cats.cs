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
public class Cats
{
    #region Private properties
    
    /// <summary>
    /// Cats list
    /// </summary>
    private List<Cat> _cats;
    #endregion

    #region Constructors
    
    /// <summary>
    /// Cats Constructor instanciate _cats
    /// </summary>
    public Cats()
    {
        _cats = new List<Cat>();
    }
    #endregion

    #region Public Methods

    /// <summary>
    /// Add one cat to the list
    /// </summary>
    /// <param name="cat"></param>
    public void Add(Cat cat)
    {
        _cats.Add(cat);
    }

    /// <summary>
    /// Delete cat from list
    /// </summary>
    /// <param name="cat"></param>
    /// <returns></returns>
    public bool Del(Cat cat)
    {
        if(_cats.Contains(cat)) 
            return _cats.Remove(cat);
        return false;
    }

    /// <summary>
    /// Get Cat by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Cat GetById(int id)
    {
        //return _cats.Find(a => a.ID == id);

        foreach (Cat cat in _cats)
        {
            if (cat.ID == id)
                return cat;
        }
        
        return null;
    }

    /// <summary>
    /// Filter cats list by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<Cat> FilterCats(string name)
    {
        return _cats.FindAll(a => a.Name == name);
    }

    /// <summary>
    /// Display details for all 
    /// </summary>
    public void DisplayAll()
    {
        foreach (Cat cat in _cats)
        {
            cat.Display();
        }
    }

    /// <summary>
    /// Clear all from list
    /// </summary>
    public void Clear()
    {
        _cats.Clear();
    }
    
    #endregion
}