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
    [SerializeField] GameObject _controlsImage;

	private bool _gameOver;
	private bool restart;
    private bool _controlsOpen = true;
    private string _sceneName;

    PlayerControl _WillieMaePlayerControl;

    // Use this for initialization
    void Start () {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        AkSoundEngine.PostEvent("Play_KidKwei_BourbonStreet_Music", gameObject);

        _WillieMaePlayerControl = GameObject.Find("WillieMae").GetComponent<PlayerControl>();

        _gameOver = false;
		restart = false;
        _healthPointsText.text = "HP: " + _WillieMaePlayerControl.HP;
		_gameOverText.text = "";

        Scene scene = SceneManager.GetActiveScene();
        _sceneName = scene.name;


    }

	// Update is called once per frame
	void Update () {
		if (_gameOver) {
            _WillieMaePlayerControl._noMoving = true;

			if (player.GetButtonDown("Jump"))
			{
                AkSoundEngine.PostEvent("Stop_KidKwei_BourbonStreet_Music", gameObject);
                _WillieMaePlayerControl._noMoving = false;
                SceneManager.LoadScene(_sceneName);
            }
		}

        if (player.GetButtonDown("Controls") && !_controlsOpen)
        {
            Debug.Log("Pause");
            _controlsImage.SetActive(true);
            _controlsOpen = true;
            _WillieMaePlayerControl._noMoving = true;
        }

        else if (player.GetButtonDown("Controls") && _controlsOpen)
        {
            Debug.Log("Unpause");
            _controlsImage.SetActive(false);
            _controlsOpen = false;
            _WillieMaePlayerControl._noMoving = false;
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
