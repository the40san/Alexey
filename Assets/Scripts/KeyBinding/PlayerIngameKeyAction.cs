namespace KeyBinding
{

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
			player.ClearPilingFrame = true;
		}
	}

	public void OnKeyRight()
	{
		if (player.CanCurrentTetriminoMoveRight())
		{
			player.CurrentTetrimino.MoveRight();
			player.ClearPilingFrame = true;
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
		Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
	}

	public void OnKeyTurnLeft()
	{
		if (player.CanCurrentTetriminoTurn(TurnDirection.Left)) {
			player.CurrentTetrimino.TurnLeft();
			player.ClearPilingFrame = true;
			Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
		}
	}

	public void OnKeyTurnRight()
	{
		if (player.CanCurrentTetriminoTurn(TurnDirection.Right)) {
			player.CurrentTetrimino.TurnRight();
			player.ClearPilingFrame = true;
			Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
		}
	}

	public void OnAnyKey() {}

	public void OnKeyLShift() {
		player.HoldCurrentTetrimino();
	}
}

}