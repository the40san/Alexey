using UnityEngine;

public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	public Tetrimino NextTetrimino {get; set;}
	private TetriminoDispenser dispenser;

	private PlayerSequence playerSequence;

	public bool SkipPilingState {get; set;}
	public bool ClearPilingFrame {get; set;}
	public bool GameOver {get;set;}

	public Map map;

	public const int TetriminoSpawnX = 6;
	public const int TetriminoSpawnY = 20;

	public void Awake () {
		InitTetriminoDispenser();
		InitPlayerSequence();
	}

	private void InitTetriminoDispenser()
	{
		GameObject newDispenser = Spawner.SpawnObject("TetriminoDispenser", gameObject);
		this.dispenser = newDispenser.GetComponent<TetriminoDispenser>();
	}

	private void InitPlayerSequence()
	{
		this.playerSequence = new PlayerSequence();
		this.playerSequence.CreatingNewTetriminoState = new CreatingNewTetriminoPlayerState(this);
		this.playerSequence.DroppingState = new DroppingPlayerState(this);
		this.playerSequence.PilingState = new PilingPlayerState(this);
		this.playerSequence.CleaningState = new CleaningPlayerState(this);
	}

	public void UpdateCurrentTetrimino()
	{
		if (CurrentTetrimino != null)
		{
			Spawner.Destroy(this.CurrentTetrimino.gameObject);
		}

		if (NextTetrimino == null)
		{
			NextTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
			NextTetrimino.transform.SetParent(this.gameObject.transform);
		}

		NextTetrimino.MoveToMapPosition(TetriminoSpawnX, TetriminoSpawnY);
		NextTetrimino.gameObject.SetActive(true);
		this.CurrentTetrimino = NextTetrimino;

		NextTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
		NextTetrimino.transform.SetParent(this.gameObject.transform);
	}

	public bool IsCurrentTetriminoPiling()
	{
		return CurrentTetrimino != null && map.IsPiling(CurrentTetrimino);
	}
	public bool CanCurrentTetriminoMoveRight()
	{
		return CurrentTetrimino != null && map.CanMoveRight(CurrentTetrimino);
	}

	public bool CanCurrentTetriminoMoveLeft()
	{
		return CurrentTetrimino != null && map.CanMoveLeft(CurrentTetrimino);
	}

	public bool CanCurrentTetriminoTurn(TurnDirection direction)
	{
		return CurrentTetrimino != null && map.CanTurn(CurrentTetrimino, direction);
	}

	public void Update()
	{
		if (!GameOver) {
			this.playerSequence.Update();
		}
	}

	public void PileCurrentTetrimino()
	{
		try
		{
			map.PileTetrimino(CurrentTetrimino);
		}
		catch (Map.BlockStackingException)
		{
			this.GameOver = true;
			GameSuperior.Instance.EndTetris();
			return;
		}
		finally
		{
			this.CurrentTetrimino.gameObject.SetActive(false);
		}
		int scoredThisTime = map.FilledLineCount();
		ScoreBoard.Instance.AddScore(scoredThisTime);

		map.CleanLines();
		// EFFECT, THEN
		map.PackLines();
	}
}
