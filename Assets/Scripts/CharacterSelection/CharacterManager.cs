using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public Text nameText;
    public SpriteRenderer spaceShipSprite;

    private int selectedOption = 0;

    void Start()
    {
        // If no ship selected default to ship 1
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
        // Load the last selected ship
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        //  moves forward in the character list

        selectedOption++;

        if(selectedOption >= characterDatabase.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();

    }

    public void BackOption()
    {
        // moves back in the character list
          
        selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        /* Gets current character from the database 
         * displays it along with its name
         */
        Character character = characterDatabase.GetCharacter(selectedOption);
        spaceShipSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        // Loads selected option by converting the assigned key value to an integer

        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        // Saves selected option by assigning a key value to that option

        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

}
