using UnityEngine;

namespace UI
{

public class Hold : MonoBehaviour {
	private static Hold _instance;
	public TetriminoShape HoldingShape
	{
		get {
			if (this.holdingTetrimino == null)
			{
				return null;
			}
			return holdingTetrimino.Shape;
		}
	}

	private Tetrimino holdingTetrimino;

	public static Hold Instance
	{
		get {
			if (_instance == null)
			{
				_instance = (Hold)FindObjectOfType(typeof(Hold));
			}

			return _instance;
		}
	}

	public void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
			return;
		}
	}

	public GameObject hold;

	public void Clear()
	{
		if (holdingTetrimino != null) {
			Spawner.Destroy(holdingTetrimino.gameObject);
		}
	}

	public void SetTetrimino(Tetrimino tetrimino)
	{
		GameObject copy = tetrimino.Shape.CreateTetorimino();
		copy.transform.position = Vector3.zero;
		copy.transform.Translate(tetrimino.TurnAxis);
		copy.transform.SetParent(this.hold.transform, false);
		copy.SetActive(true);

		Clear();
		this.holdingTetrimino = copy.GetComponent<Tetrimino>();
	}
}

}