using UnityEngine;
public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	private TetriminoDispenser 	dispenser;

	private PlayerSequence playerSequence;

	public PlayerAttribute Attribute {
		get {
			return this._attribute;
		}
	}
	private PlayerAttribute _attribute;

	public Map map;

	public const int TetriminoSpawnX = 6;
	public const int TetriminoSpawnY = 20;

	public void Awake () {
		InitTetriminoDispenser();
		InitPlayerSequence();
		InitPlayerAttribute();
	}

	private void InitTetriminoDispenser()
	{
		GameObject newDispenser = Spawner.SpawnObject("TetriminoDispenser", gameObject);
		this.dispenser = newDispenser.GetComponent<TetriminoDispenser>();
	}

	private void InitPlayerSequence()
	{
		this.playerSequence = new PlayerSequence(this);
	}

	private void InitPlayerAttribute()
	{
		this._attribute = new PlayerAttribute();
	}

	public void UpdateCurrentTetrimino()
	{
		if (CurrentTetrimino != null)
		{
			Spawner.Destroy(this.CurrentTetrimino.gameObject);
		}

		Tetrimino newTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
		newTetrimino.transform.SetParent(this.gameObject.transform);
		newTetrimino.MoveToMapPosition(TetriminoSpawnX, TetriminoSpawnY);
		newTetrimino.gameObject.SetActive(true);

		this.CurrentTetrimino = newTetrimino;
	}

	public void HoldCurrentTetrimino()
	{
		if (Attribute.HoldUsed) {
			return;
		}
		Attribute.HoldUsed = true;

		TetriminoShape holdingShape = UI.Hold.Instance.HoldingShape;
		UI.Hold.Instance.SetTetrimino(this.CurrentTetrimino);

		if (holdingShape == null)
		{
			UpdateCurrentTetrimino();
		}
		else
		{
			Spawner.Destroy(this.CurrentTetrimino.gameObject);
			this.CurrentTetrimino = holdingShape.CreateTetorimino().GetComponent<Tetrimino>();
			this.CurrentTetrimino.transform.SetParent(this.gameObject.transform);
			this.CurrentTetrimino.MoveToMapPosition(TetriminoSpawnX, TetriminoSpawnY);
			this.CurrentTetrimino.gameObject.SetActive(true);
		}
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

	public TetriminoTurn TrySuperRotation(TurnDirection direction)
	{
 		if (CurrentTetrimino == null) {
			return null;
		}

		TetriminoTurn[] list = new TetriminoTurn[] {
			new TetriminoTurn(CurrentTetrimino, direction, Vector3.zero),
			new TetriminoTurn(CurrentTetrimino, direction, Vector3.left),
			new TetriminoTurn(CurrentTetrimino, direction, Vector3.left + Vector3.down),
			new TetriminoTurn(CurrentTetrimino, direction, Vector3.right),
			new TetriminoTurn(CurrentTetrimino, direction, Vector3.right + Vector3.down)
		};

		foreach (TetriminoTurn turn in list)
		{
			if (map.CanTurn(turn)) {
				return turn;
			}

		}
		return null;
	}

	public void Update()
	{
		if (!this.Attribute.GameOver) {
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
			this.Attribute.GameOver = true;
			Manager.GameSuperior.Instance.EndTetris();
			return;
		}
		finally
		{
			this.CurrentTetrimino.gameObject.SetActive(false);
		}
		int scoredThisTime = map.FilledLineCount();

		if (scoredThisTime > 0)
		{
			UI.ScoreBoard.Instance.AddScore(scoredThisTime);
			Manager.AudioController.Instance.PlaySe(SfxId.LineClear);
			Attribute.UpdateGameSpeed();
		}

		map.CleanLines();
		// EFFECT, THEN
		map.PackLines();
	}
}
