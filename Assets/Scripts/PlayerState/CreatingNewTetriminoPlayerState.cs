public class CreatingNewTetriminoPlayerState : IPlayerState
{
	private Player player;

	public CreatingNewTetriminoPlayerState(Player player)
	{
		this.player = player;
	}

	public void OnUpdate(int _frameCount)
	{
		player.UpdateCurrentTetrimino();
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
