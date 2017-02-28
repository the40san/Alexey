namespace PlayerState
{

public class PilingPlayerState : IPlayerState
{
	public const int pilingFrame = 30;

	private int frameCount;


	private Player player;
	public PilingPlayerState(Player player)
	{
		this.player = player;
		this.frameCount = 0;
	}

	public void OnUpdate(int _frameCount)
	{
		// Clear frameCount when you used rotate or move key
		if (player.Attribute.ClearPilingFrame)
		{
			player.Attribute.ClearPilingFrame = false;
			this.frameCount = 0;
		}
		else {
			this.frameCount++;
		}
	}

	public bool CanTransitionPreviousState()
	{
		return !player.IsCurrentTetriminoPiling();
	}

	public bool CanTransitionNextState(int _frameCount)
	{
		return player.Attribute.SkipPilingState || this.frameCount >= pilingFrame;
	}
}

}