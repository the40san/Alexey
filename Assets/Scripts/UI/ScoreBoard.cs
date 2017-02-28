using UnityEngine;
using UnityEngine.UI;

namespace UI
{

public class ScoreBoard : MonoBehaviour {

	private int highScore;
	private int currentScore;
	public int CurrentScore {
		get {
			return currentScore;
		}
	}


	[SerializeField]
	private Text highScoreText;
	[SerializeField]
	private Text currentScoreText;


	private static ScoreBoard _instance;

	public static ScoreBoard Instance
	{
		get {
			if (_instance == null)
			{
				_instance = (ScoreBoard)FindObjectOfType(typeof(ScoreBoard));
			}

			return _instance;
		}
	}

	public void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Clear();
	}

	public void Clear()
	{
		this.highScore = 0;
		this.currentScore = 0;
	}


	public void AddScore(int newScore)
	{
		this.currentScore += newScore;
		if (this.highScore < currentScore) this.highScore = currentScore;

		currentScoreText.text = currentScore.ToString();
		highScoreText.text = highScore.ToString();
	}
}

}