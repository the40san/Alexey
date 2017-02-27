public class TitleScreenKeyAction : IKeyAction {
	public void OnKeyLeft() {}
	public void OnKeyRight() {}
	public void OnKeyDown() {}
	public void OnKeySpace() {}
	public void OnKeyTurnLeft() {}
	public void OnKeyTurnRight() {}

	public void OnAnyKey() {
		GameSuperior.Instance.StartTetris();
	}

	public void OnKeyLShift() {}
}
