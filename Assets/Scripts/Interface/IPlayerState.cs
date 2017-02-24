public interface IPlayerState
{
	bool CanTransitionNextState(int frameCount);
	bool CanTransitionPreviousState();
	void OnUpdate (int frameCount);
}

public enum PlayerState
{
	CreatingNewTetrimino,
	Dropping,
	Piling,
	Cleaning
}