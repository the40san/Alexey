using UnityEngine;

public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	public Tetrimino NextTetrimino {get; set;}
	private TetriminoDispenser dispenser;

	private PlayerSequence playerSequence;

	public bool SkipPilingState {get; set;}
	public bool ClearPilingFrame {get; set;}

	public Map map;

	public const int TetriminoSpawnX = 6;
	public const int TetriminoSpawnY = 20;


	public void Start () {
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
		if (NextTetrimino == null) {
			NextTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
		}

		NextTetrimino.MoveToMapPosition(TetriminoSpawnX, TetriminoSpawnY);
		NextTetrimino.gameObject.SetActive(true);
		NextTetrimino.transform.SetParent(this.gameObject.transform);
		this.CurrentTetrimino = NextTetrimino;

		NextTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
	}

	public bool IsCurrentTetriminoPiling()
	{
		return map.IsPiling(CurrentTetrimino);
	}
	public bool CanCurrentTetriminoMoveRight()
	{
		return map.CanMoveRight(CurrentTetrimino);
	}

	public bool CanCurrentTetriminoMoveLeft()
	{
		return map.CanMoveLeft(CurrentTetrimino);
	}

	public bool CanCurrentTetriminoTurn(TurnDirection direction)
	{
		return map.CanTurn(CurrentTetrimino, direction);
	}

	// TODO MOVE THIS TO TICK
	public void Update()
	{
		this.playerSequence.Update();
	}

	public void PileCurrentTetrimino()
	{
		map.PileTetrimino(CurrentTetrimino);
		int scoredThisTime = map.FilledLineCount();
		ScoreBoard.Instance.AddScore(scoredThisTime);

		map.CleanLines();
		// EFFECT, THEN
		map.PackLines();
	}
}
