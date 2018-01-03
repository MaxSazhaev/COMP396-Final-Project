/* Author: Max Sazhaev, Joshua Korovesi
 * File: Menu2.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the functionality of the menu.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour
{
    public Canvas quitMenu2;
    public Button startText2;
    public Button exitText2;

    void Start()
    {
        quitMenu2 = quitMenu2.GetComponent<Canvas>();
        startText2 = startText2.GetComponent<Button>();
        exitText2 = exitText2.GetComponent<Button>();
        quitMenu2.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu2.enabled = true;
        startText2.enabled = false;
        exitText2.enabled = false;
    }

    public void NoPress()
    {
        quitMenu2.enabled = false;
        startText2.enabled = true;
        exitText2.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}