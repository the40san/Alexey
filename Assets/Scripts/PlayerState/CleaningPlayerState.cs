public class CleaningPlayerState : IPlayerState
{
	private Player player;
	public const int GameSpeed = 60;

	public CleaningPlayerState(Player player)
	{
		this.player = player;
	}

	public void OnUpdate(int _frameCount)
	{
		player.SkipPilingState = false;
		player.HoldUsed = false;
		player.PileCurrentTetrimino();
	}

	public bool CanTransitionPreviousState()
	{
		return false;
	}

	public bool CanTransitionNextState(int _frameCount)
	{
		return true;
	}
}