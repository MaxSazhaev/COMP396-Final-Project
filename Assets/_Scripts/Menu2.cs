/* Author: Max Sazhaev, Joshua Korovesi
 * File: Menu2.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the functionality of the menu.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public Canvas quitMenu2;
    public Button startText2;
    public Button exitText2;
    public Text scoreText;
    public AudioClip death;

    void Start()
    {
        quitMenu2 = quitMenu2.GetComponent<Canvas>();
        startText2 = startText2.GetComponent<Button>();
        exitText2 = exitText2.GetComponent<Button>();
        scoreText = scoreText.GetComponent<Text>();
        scoreText.text = "Final Score: " + PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("score", 0);
        quitMenu2.enabled = false;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;
        AudioSource.PlayClipAtPoint(death, transform.position);
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
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        if(currentSceneName == "Death")
        {
            string sceneName = PlayerPrefs.GetString("lastLoadedScene");
            SceneManager.LoadScene(sceneName);
        }
        else if(currentSceneName == "Finish")
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}