using UnityEngine;

public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	public Tetrimino NextTetrimino {get; set;}
	private TetriminoDispenser dispenser;

	public Map map;

	public void Start () {
		InitTetriminoDispenser();
		UpdateCurrentTetrimino();
	}

	private void InitTetriminoDispenser()
	{
		GameObject newDispenser = Spawner.SpawnObject("TetriminoDispenser", gameObject);
		this.dispenser = newDispenser.GetComponent<TetriminoDispenser>();
	}

	public void UpdateCurrentTetrimino()
	{
		if (NextTetrimino == null) {
			NextTetrimino = dispenser.CreateNext().GetComponent<Tetrimino>();
		}

		NextTetrimino.MoveToMapPosition(3, 19); // TODO
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

	// TODO MOVE THIS TO TICK
	public void Update()
	{
		if (IsCurrentTetriminoPiling())
		{
			map.PileTetrimino(CurrentTetrimino);
			UpdateCurrentTetrimino();
		}
	}
}
