public class PlayerIngameKeyAction : IKeyAction
{
	private Player player;

	public PlayerIngameKeyAction(Player player)
	{
		this.player = player;
	}

	public void OnKeyLeft()
	{
		if (player.CanCurrentTetriminoMoveLeft())
		{
			player.CurrentTetrimino.MoveLeft();
		}
	}

	public void OnKeyRight()
	{
		if (player.CanCurrentTetriminoMoveRight())
		{
			player.CurrentTetrimino.MoveRight();
		}
	}

	public void OnKeyDown()
	{
		if (!player.IsCurrentTetriminoPiling()) {
			player.CurrentTetrimino.MoveDown();
		}
	}
	public void OnKeySpace()
	{
		while(!player.IsCurrentTetriminoPiling())
		{
			player.CurrentTetrimino.MoveDown();
		}
		player.SkipPilingState = true;
	}

	public void OnKeyTurnLeft()
	{
		if (player.CanCurrentTetriminoTurn(TurnDirection.Left)) {
			player.CurrentTetrimino.TurnLeft();
		}
	}

	public void OnKeyTurnRight()
	{
		if (player.CanCurrentTetriminoTurn(TurnDirection.Right)) {
			player.CurrentTetrimino.TurnRight();
		}
	}
}
