using UnityEngine;

public class Player : MonoBehaviour {
	public Tetrimino CurrentTetrimino {get; set;}
	private TetriminoDispenser dispenser;

	public void Start () {
		InitTetriminoDispenser();
		CreateNextTetrimino();
	}

	private void InitTetriminoDispenser()
	{
		GameObject newDispenser = Spawner.SpawnObject("TetriminoDispenser", gameObject);
		this.dispenser = newDispenser.GetComponent<TetriminoDispenser>();
	}

	public void CreateNextTetrimino()
	{
		GameObject newTetrimino = dispenser.CreateNext();
		newTetrimino.transform.SetParent(this.gameObject.transform);
		this.CurrentTetrimino = newTetrimino.GetComponent<Tetrimino>();
	}
}
