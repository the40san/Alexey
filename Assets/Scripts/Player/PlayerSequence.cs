using PlayerState;
public class PlayerSequence {
	public IPlayerState CreatingNewTetriminoState {get;set;}
	public IPlayerState DroppingState {get;set;}
	public IPlayerState PilingState {get;set;}
	public IPlayerState CleaningState {get;set;}

	private PlayerSequenceState currentPlayerState = PlayerSequenceState.CreatingNewTetrimino;

	public int frameCount = 0;

	public PlayerSequence(Player player)
	{
		this.CreatingNewTetriminoState = new CreatingNewTetriminoPlayerState(player);
		this.DroppingState = new DroppingPlayerState(player);
		this.PilingState = new PilingPlayerState(player);
		this.CleaningState = new CleaningPlayerState(player);
	}

	public void Update () {
		ExecuteOnUpdate();
		IncrementFrameCount();
	}

	private void ExecuteOnUpdate()
	{
		GetPlayerState(currentPlayerState).OnUpdate(frameCount);
	}

	private IPlayerState GetPlayerState(PlayerSequenceState state)
	{
		switch(state)
		{
			case PlayerSequenceState.CreatingNewTetrimino:
				return CreatingNewTetriminoState;
			case PlayerSequenceState.Dropping:
				return DroppingState;
			case PlayerSequenceState.Piling:
				return PilingState;
			case PlayerSequenceState.Cleaning:
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
		if (currentPlayerState == PlayerSequenceState.Cleaning)
		{
			currentPlayerState = PlayerSequenceState.CreatingNewTetrimino;
			return;
		}
		currentPlayerState = currentPlayerState + 1;
	}

	private void TransitionToPreviousPlayerState()
	{
		if (currentPlayerState == PlayerSequenceState.CreatingNewTetrimino)
		{
			// unreachable, maybe.
			currentPlayerState = PlayerSequenceState.Cleaning;
			return;
		}

		currentPlayerState = currentPlayerState - 1;
	}
}