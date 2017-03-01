using System;
public class PlayerAttribute {
	public bool SkipPilingState {get; set;}
	public bool ClearPilingFrame {get; set;}
	public bool GameOver {get;set;}

	public bool HoldUsed {get; set;}


	public const int DefaultGameSpeed = 60;
	public const int MaxGameSpeed = 1;

	// logbase = 1000^(1/60)
	public const double GameSpeedLogBase = 1.122;

	private int currentGameSpeed = DefaultGameSpeed;

	public int GameSpeed {
		get {
			return currentGameSpeed;
		}
	}

	public void UpdateGameSpeed()
	{
		int currentScore = UI.ScoreBoard.Instance.CurrentScore;
		this.currentGameSpeed = DefaultGameSpeed - (int)Math.Log(currentScore + 1, GameSpeedLogBase);
		if (this.currentGameSpeed < MaxGameSpeed) {
			this.currentGameSpeed = MaxGameSpeed;
		}
	}

	public PlayerAttribute()
	{
		this.SkipPilingState = false;
		this.ClearPilingFrame = false;
		this.GameOver = false;
		this.HoldUsed = false;
	}
}