public class PlayerIngameKeyAction : IKeyAction
{
	private Player player;

	public PlayerIngameKeyAction(Player player)
	{
		this.player = player;
	}

	public void OnKeyLeft()
	{
		player.CurrentTetrimino.MoveLeft();
	}

	public void OnKeyRight()
	{
		player.CurrentTetrimino.MoveRight();
	}
	public void OnKeyDown()
	{
		player.CurrentTetrimino.MoveDown();
	}
	public void OnKeySpace()
	{
		player.CurrentTetrimino.MoveDown();
	}
}
