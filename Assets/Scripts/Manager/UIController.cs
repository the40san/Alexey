using UnityEngine;

public class UIController : MonoBehaviour {
	private ScoreBoard _scoreBoard;

	private Title _title;

	private GameOver _gameOver;

	public ScoreBoard ScoreBoard {
		get {
			if (_scoreBoard == null)
			{
				this._scoreBoard = (ScoreBoard)FindObjectOfType(typeof(ScoreBoard));
			}
			return _scoreBoard;
		}
	}

	public Title Title {
		get {
			if (_title == null)
			{
				this._title = (Title)FindObjectOfType(typeof(Title));
			}
			return _title;
		}
	}

	public GameOver GameOver {
		get {
			if (_gameOver == null) {
				this._gameOver= (GameOver)FindObjectOfType(typeof(GameOver));
			}
			return _gameOver;
		}
	}
}
