public class GameOverMenu {
	public enum GameOverOption {
		Restart,
		GoToTitle
	}

	private GameOverOption currentOption = GameOverOption.Restart;
	public GameOverOption CurrentOption {
		get {
			return currentOption;
		}
	}

	public GameOverMenu()
	{
	}

	public void ToggleOption()
	{
		if (this.currentOption == GameOverOption.GoToTitle)
		{
			this.currentOption = GameOverOption.Restart;
			return;
		}

		this.currentOption++;
	}

	public void SelectOption()
	{
		switch(currentOption)
		{
			case GameOverOption.Restart:
				GameSuperior.Instance.StartTetris();
				break;
			case GameOverOption.GoToTitle:
				GameSuperior.Instance.GoToTitle();
				break;
		}
	}
}