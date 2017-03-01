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
			player.Attribute.ClearPilingFrame = true;
		}
	}

	public void OnKeyRight()
	{
		if (player.CanCurrentTetriminoMoveRight())
		{
			player.CurrentTetrimino.MoveRight();
			player.Attribute.ClearPilingFrame = true;
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
		player.Attribute.SkipPilingState = true;
		Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
	}

	public void OnKeyTurnLeft()
	{
		TetriminoTurn turn = player.TrySuperRotation(TurnDirection.Left);
		if (turn != null) {
			turn.TurnTetrimino();
			player.Attribute.ClearPilingFrame = true;
			Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
		}
	}

	public void OnKeyTurnRight()
	{
		TetriminoTurn turn = player.TrySuperRotation(TurnDirection.Right);
		if (turn != null) {
			turn.TurnTetrimino();
			player.Attribute.ClearPilingFrame = true;
			Manager.AudioController.Instance.PlaySe(SfxId.TetriminoTurn);
		}
	}

	public void OnAnyKey() {}

	public void OnKeyLShift() {
		player.HoldCurrentTetrimino();
	}
}

}