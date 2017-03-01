namespace PlayerState
{

public class DroppingPlayerState : IPlayerState
{
	private Player player;

	public DroppingPlayerState(Player player)
	{
		this.player = player;
	}

	public void OnUpdate(int frameCount)
	{
		if (frameCount % player.Attribute.GameSpeed != 0 && frameCount != 0)
		{
			return;
		}

		if (!player.IsCurrentTetriminoPiling()) {
			player.CurrentTetrimino.MoveDown();
		}
	}

	public bool CanTransitionPreviousState()
	{
		return false;
	}

	public bool CanTransitionNextState(int _frameCount)
	{
		return player.IsCurrentTetriminoPiling();
	}
}

}