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

	public int HighScore {
		get {
			return highScore;
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
		this.highScore = 0;
		Clear();
	}

	public void Clear()
	{
		this.currentScore = 0;
		UpdateScoreText();
	}


	public void AddScore(int newScore)
	{
		this.currentScore += newScore;
		if (this.highScore < currentScore) this.highScore = currentScore;
		UpdateScoreText();
	}

	public void UpdateHighScore(int highScore)
	{
		this.highScore = highScore;
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		currentScoreText.text = currentScore.ToString();
		highScoreText.text = highScore.ToString();
	}
}

}