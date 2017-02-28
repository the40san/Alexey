using UnityEngine;
using UI;

namespace Manager
{

public class UIController : MonoBehaviour {
	private Title _title;

	private GameOver _gameOver;

	public ScoreBoard ScoreBoard {
		get {
			return ScoreBoard.Instance;
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
				this._gameOver = (GameOver)FindObjectOfType(typeof(GameOver));
			}
			return _gameOver;
		}
	}

	public Hold Hold {
		get {
			return Hold.Instance;
		}
	}

	public Next Next {
		get {
			return Next.Instance;
		}
	}
}

}