namespace KeyBinding
{

public class TitleScreenKeyAction : IKeyAction {
	public void OnKeyLeft() {}
	public void OnKeyRight() {}
	public void OnKeyDown() {}
	public void OnKeySpace() {}
	public void OnKeyTurnLeft() {}
	public void OnKeyTurnRight() {}

	public void OnAnyKey() {
		Manager.GameSuperior.Instance.StartTetris();
	}

	public void OnKeyLShift() {}
}

}