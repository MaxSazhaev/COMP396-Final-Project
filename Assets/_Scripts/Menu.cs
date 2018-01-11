/* Author: Max Sazhaev
 * File: Menu.cs
 * Creation Date: December 18th 2017
 * Description: This script controls the functionality of the menu.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int finished;
    public Canvas quitMenu;
    public Button optionsText;
    public Canvas optionsMenu;
    public Button startText;
    public Button exitText;
    public Canvas instructionMenu;
    public Button instructionText;
    public Button medium;
    public Button hard;
    public int difficulty;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        
        difficulty = 1;
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        instructionMenu = instructionMenu.GetComponent<Canvas>();
        instructionText = instructionText.GetComponent<Button>();
        hard = hard.GetComponent<Button>();
        medium = medium.GetComponent<Button>();
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
        finished = PlayerPrefs.GetInt("finished", 0);
        if (finished == 1)
        {
            medium.enabled = true;
            hard.enabled = true;
        }
        else
        {
            medium.enabled = false;
            hard.enabled = false;
        }
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
        if (difficulty == 1)
        {
            PlayerPrefs.SetInt("subLife", 2);
            PlayerPrefs.SetInt("scorePickup", 100);
            PlayerPrefs.SetInt("scoreConvert", 1000);
        }
        else if(difficulty == 2)
        {
            PlayerPrefs.SetInt("subLife", 5);
            PlayerPrefs.SetInt("scorePickup", 200);
            PlayerPrefs.SetInt("scoreConvert", 2000);
        }
        else if (difficulty == 3)
        {
            PlayerPrefs.SetInt("subLife", 10);
            PlayerPrefs.SetInt("scorePickup", 400);
            PlayerPrefs.SetInt("scoreConvert", 4000);
        }
        else
        {
            PlayerPrefs.SetInt("subLife", 2);
            PlayerPrefs.SetInt("scorePickup", 100);
            PlayerPrefs.SetInt("scoreConvert", 1000);
        }
        PlayerPrefs.SetInt("finished", 0);
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}