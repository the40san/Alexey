public class PilingPlayerState : IPlayerState
{
	public const int pilingFrame = 30;
	private Player player;
	public PilingPlayerState(Player player)
	{
		this.player = player;
	}

	public void OnUpdate(int frameCount)
	{
		// do nothing
	}

	public bool CanTransitionPreviousState()
	{
		return !player.IsCurrentTetriminoPiling();
	}

	public bool CanTransitionNextState(int frameCount)
	{
		return frameCount >= pilingFrame;
	}
}