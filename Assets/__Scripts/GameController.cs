using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class GameController : MonoBehaviour {

    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    public Text _healthPointsText;
	public Text _gameOverText;

	private bool _gameOver;
	private bool restart;
    private string _sceneName;

    PlayerControl _WillieMaePlayerControl;

    // Use this for initialization
    void Start () {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        _WillieMaePlayerControl = GameObject.Find("WillieMae").GetComponent<PlayerControl>();

        _gameOver = false;
		restart = false;
        _healthPointsText.text = "HP: " + _WillieMaePlayerControl.HP;
		_gameOverText.text = "";
        _sceneName = SceneManager.GetSceneByName();


    }

	// Update is called once per frame
	void Update () {
		if (_gameOver) {
			if (player.GetButtonDown("Jump"))
			{
                SceneManager.LoadScene();
            }
		}
	}

    public void UpdateHP()
    {
        _healthPointsText.text = "HP: " + _WillieMaePlayerControl.HP;
    }


	public void GameOver ()
	{
		_gameOverText.text = "Press Jump to restart level";
		_gameOver = true;
	}

}
