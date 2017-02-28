public class PlayerAttribute {
	public bool SkipPilingState {get; set;}
	public bool ClearPilingFrame {get; set;}
	public bool GameOver {get;set;}

	public bool HoldUsed {get; set;}

	public PlayerAttribute()
	{
		this.SkipPilingState = false;
		this.ClearPilingFrame = false;
		this.GameOver = false;
		this.HoldUsed = false;
	}
}