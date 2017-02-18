﻿public class PlayerIngameKeyAction : IKeyAction
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
		player.CurrentTetrimino.MoveDown();
	}
}