/* Author: Max Sazhaev, Joshua Korovesi
 * File: GameController.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the way the player functions, life, score, and time.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public Text scoreLabel;
    public Text lifeLabel;
    public Text timeLabel;
    public Text remainingLabel;



    // PRIVATE INSTANCE VARIABLES
    private float time = 0.0f;
    private float threshold = 1.0f;
    float seconds = 0f;
    float minutes = 0f;
    float newSeconds = 0f;
    public int _scoreValue = 0;
    private int _liveValue = 100;

    [SyncVar(hook = "OnRemainingValueChanged")]
    public int _remainingValue;

    // PUBLIC PROPERTIES
    public int Score {
        get {
            return _scoreValue;
        }
        set {
            _scoreValue = value;
            this._updateHUD();
        }
    }

    public int Remaining
    {
        get
        {
            return _remainingValue;
        }
        set
        {
            _remainingValue = value;
            this._updateHUD();
        }
    }

    public int Life {
        get {
            return _liveValue;
        }
        set {
            _liveValue = value;
            this._updateHUD();
        }
    }

    // Use this for initialization
    void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);
        if (sceneName == "Level1")
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            _remainingValue = 10;
        }
        else if (sceneName == "Level2")
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            _remainingValue = 4;
        }
        else if (sceneName == "Level3")
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            _remainingValue = 2;
        }
        newSeconds = Time.realtimeSinceStartup;
        this._updateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        seconds = Time.realtimeSinceStartup - newSeconds;
        if (seconds > 60)
        {
            seconds = 0;
            newSeconds = Time.realtimeSinceStartup;
            minutes++;
        }

        timeLabel.text = "Time : " + (int)minutes + " : " + (int)seconds;

        time += Time.deltaTime;
        if (time >= threshold)
        {
            time = 0.0f;
            _liveValue = _liveValue - 2;
            UpdateLife();
            if (_liveValue <= 0)
            {
                Application.LoadLevel(3);
            }
        }

    }

    // PRIVATE METHODS
    private void _updateHUD() {
        this.scoreLabel.text = "Score: " + this._scoreValue;
        this.lifeLabel.text = "Life: " + this._liveValue;
        this.remainingLabel.text = "Humans Left: " + this._remainingValue;
    }

    // Adds score to existing score
    public void AddScore(int newScoreValue)
    {
        _scoreValue += newScoreValue;
        UpdateScore();
    }

    public void OnRemainingValueChanged(int newValue)
    {
        Remaining = newValue;
        UpdateRemaining();
    }

    public void SubtractRemaining(int newRemainingValue)
    {
        OnRemainingValueChanged(_remainingValue - newRemainingValue);
       
    }
    // Subtracts Life
    public void AddLife(int newLifeValue)
    {
        _liveValue += newLifeValue;
        UpdateLife();
    }

    void UpdateLife()
    {
        lifeLabel.text = "Life: " + _liveValue;
    }

    // Shows format for updated score
    void UpdateScore()
    {
        scoreLabel.text = "Score: " + _scoreValue;
    }

    void UpdateRemaining()
    {
        remainingLabel.text = "Humans Left: " + _remainingValue;
    }

}
