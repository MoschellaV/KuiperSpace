using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // Marks/Creates this ScriptableObject to be listed in the Assets/Create submenu 
public class CharacterDatabase : ScriptableObject 
    // ScriptableObject is a data container that stores data, independent from script instances
    // This database is better seen in unity
{
    public Character[] character;
    // List of characters

    public int CharacterCount
    // Gets the length of the character list
    {
        get
        {
            return character.Length;
        }
    }

    public Character GetCharacter(int index)
    // Method that return the characters index
    {
        return character[index];
    }

}
