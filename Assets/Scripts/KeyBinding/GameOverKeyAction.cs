namespace KeyBinding
{

public class GameOverKeyAction : IKeyAction
{
	private Manager.GameOverMenu gameOverMenu;

	public GameOverKeyAction(Manager.GameOverMenu gameOverMenu)
	{
		this.gameOverMenu = gameOverMenu;
	}

	public void OnKeyLeft() {
		gameOverMenu.ToggleOption();
	}
	public void OnKeyRight() {
		gameOverMenu.ToggleOption();
	}
	public void OnKeyDown() {
		gameOverMenu.ToggleOption();
	}

	public void OnKeySpace() {
		gameOverMenu.SelectOption();
	}

	public void OnKeyTurnLeft() {}
	public void OnKeyTurnRight() {}

	public void OnAnyKey() {}
	public void OnKeyLShift() {}
}

}