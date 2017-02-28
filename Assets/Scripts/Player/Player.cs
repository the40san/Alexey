using UnityEngine;
public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	public Tetrimino NextTetrimino {get; set;}
	private TetriminoDispenser dispenser;

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

		this._attribute = new PlayerAttribute();
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

	public bool CanCurrentTetriminoTurn(TurnDirection direction)
	{
		return CurrentTetrimino != null && map.CanTurn(CurrentTetrimino, direction);
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
		}

		map.CleanLines();
		// EFFECT, THEN
		map.PackLines();
	}
}
