/* Author: Max Sazhaev, Joshua Korovesi
 * File: GameController.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the way the player functions, life, score, and time.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public Text scoreLabel;
	public Text lifeLabel;
    public Text timeLabel;

	// PRIVATE INSTANCE VARIABLES
    float seconds = 0f;
    float minutes = 0f;
    float newSeconds = 0f;
	private int _scoreValue = 0;
	private int _liveValue = 100;

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
	void Start () {
        newSeconds = Time.realtimeSinceStartup;
		this._updateHUD ();
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

    }

	// PRIVATE METHODS
	private void _updateHUD() {
		this.scoreLabel.text = "Score: " + this._scoreValue;
		this.lifeLabel.text = "Life: " + this._liveValue;
	}

    // Adds score to existing score
    public void AddScore(int newScoreValue)
    {
        _scoreValue += newScoreValue;
        UpdateScore();
    }
    // Subtracts Life
    public void SubtractLife(int newLifeValue)
    {
        _liveValue += newLifeValue;
        UpdateLife();
        if (_liveValue == 0)
        {
            Application.LoadLevel(3);
        }
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

}
