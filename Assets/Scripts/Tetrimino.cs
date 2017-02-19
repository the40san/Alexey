using UnityEngine;

public class Tetrimino : MonoBehaviour, IMovable, ITurnable {
	public Vector3 _turnAxis;
	public Vector3 TurnAxis {
		get {
			if (this._turnAxis == null)
			{
				this._turnAxis = new Vector3();
			}
			return this._turnAxis;
		}
		set {
			this._turnAxis = value;
		}
	}

	public void MoveLeft()
	{
		transform.Translate(-1, 0, 0);
	}
	public void MoveRight()
	{
		transform.Translate(1, 0, 0);
	}

	public void MoveDown()
	{
		transform.Translate(0, -1, 0);
	}

	public void TurnLeft()
	{
		foreach(Transform blockTransform in transform)
		{
			blockTransform.localPosition = new Vector3(
				-(blockTransform.localPosition.y + TurnAxis.y) - TurnAxis.x,
				(blockTransform.localPosition.x + TurnAxis.x) - TurnAxis.y,
				0
			);
		}
	}

	public void TurnRight()
	{
		foreach(Transform blockTransform in transform)
		{
			blockTransform.localPosition = new Vector3(
				(blockTransform.localPosition.y + TurnAxis.y) - TurnAxis.x,
				-(blockTransform.localPosition.x + TurnAxis.x) - TurnAxis.y,
				0
			);
		}
	}

	public void MoveToMapPosition(int x, int y)
	{
		float nx = x - Map.Width / 2 + 0.5f;
		float ny = y - Map.Height / 2 + 0.5f;
		float nz = 0;
		transform.position = new Vector3(nx, ny, nz);
	}
}