using UnityEngine;

public class Player : MonoBehaviour {

	private Tetrimino currentTetrimino;
	private TetriminoDispenser dispenser;

	public void Start () {
		InitTetriminoDispenser();
		InitCurrentTetrimino();
	}

	private void InitTetriminoDispenser()
	{
		GameObject newDispenser = Spawner.SpawnObject("TetriminoDispenser", gameObject);
		this.dispenser = newDispenser.GetComponent<TetriminoDispenser>();
	}

	private void InitCurrentTetrimino()
	{
		GameObject newTetrimino = dispenser.CreateNext();
		newTetrimino.transform.SetParent(this.gameObject.transform);
	}

	void Update () {

	}
}
