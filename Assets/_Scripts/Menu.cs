/* Author: Max Sazhaev, Joshua Korovesi
 * File: Menu.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the functionality of the menu.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas quitMenu;
    public Button optionsText;
    public Canvas optionsMenu;
    public Button startText;
    public Button exitText;
    public Canvas instructionMenu;
    public Button instructionText;
    public int difficulty;

    void Start()
    {
        difficulty = 1;
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        instructionMenu = instructionMenu.GetComponent<Canvas>();
        instructionText = instructionText.GetComponent<Button>();
        optionsText = instructionText.GetComponent<Button>();
        optionsMenu.enabled = false;
        instructionMenu.enabled = false;
    }

    public void InstructionsPress()
    {
        instructionMenu.enabled = true;
        instructionText.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        optionsText.enabled = false;
    }

    public void OptionsPress()
    {
        optionsMenu.enabled = true;
        instructionText.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        optionsText.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        optionsText.enabled = false;
        instructionText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionText.enabled = true;
        optionsText.enabled = true;
    }

    public void BackPress()
    {
        instructionMenu.enabled = false;
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionText.enabled = true;
        optionsText.enabled = true;
    }

    public void EasyPress()
    {
        difficulty = 1;
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionText.enabled = true;
        optionsText.enabled = true;
    }

    public void MediumPress()
    {
        difficulty = 2;
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionText.enabled = true;
        optionsText.enabled = true;
    }
    public void HardPress()
    {
        difficulty = 3;
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionText.enabled = true;
        optionsText.enabled = true;
    }

    public void MusicOnPress()
    {
        AudioListener.pause = false;
        AudioListener.volume = 0.2f;
    }

    public void MusicOffPress()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    public void StartLevel()
    {
        if(difficulty == 1)
        {
            Application.LoadLevel(1);
        }
        else if(difficulty == 2)
        {
            Application.LoadLevel(2);
        }
        else if (difficulty == 3)
        {
            Application.LoadLevel(4);
        }
        else
        {
            Application.LoadLevel(1);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}