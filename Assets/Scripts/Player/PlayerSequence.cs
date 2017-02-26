public class PlayerSequence {
	public IPlayerState CreatingNewTetriminoState {get;set;}
	public IPlayerState DroppingState {get;set;}
	public IPlayerState PilingState {get;set;}
	public IPlayerState CleaningState {get;set;}

	private PlayerState currentPlayerState = PlayerState.CreatingNewTetrimino;

	public int frameCount = 0;

	public void Update () {
		ExecuteOnUpdate();
		IncrementFrameCount();
	}

	private void ExecuteOnUpdate()
	{
		GetPlayerState(currentPlayerState).OnUpdate(frameCount);
	}

	private IPlayerState GetPlayerState(PlayerState state)
	{
		switch(state)
		{
			case PlayerState.CreatingNewTetrimino:
				return CreatingNewTetriminoState;
			case PlayerState.Dropping:
				return DroppingState;
			case PlayerState.Piling:
				return PilingState;
			case PlayerState.Cleaning:
				return CleaningState;
		}
		return null;
	}


	private void IncrementFrameCount()
	{
		if (GetPlayerState(currentPlayerState).CanTransitionNextState(frameCount))
		{
			TransitionToNextPlayerState();
			frameCount = 0;
			return;
		}
		if (GetPlayerState(currentPlayerState).CanTransitionPreviousState())
		{
			TransitionToPreviousPlayerState();
			frameCount = 0;
			return;
		}

		frameCount++;
	}

	private void TransitionToNextPlayerState()
	{
		if (currentPlayerState == PlayerState.Cleaning)
		{
			currentPlayerState = PlayerState.CreatingNewTetrimino;
			return;
		}
		currentPlayerState = currentPlayerState + 1;
	}

	private void TransitionToPreviousPlayerState()
	{
		if (currentPlayerState == PlayerState.CreatingNewTetrimino)
		{
			// unreachable, maybe.
			currentPlayerState = PlayerState.Cleaning;
			return;
		}

		currentPlayerState = currentPlayerState - 1;
	}
}