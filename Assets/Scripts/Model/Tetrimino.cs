using UnityEngine;
using System.Collections.Generic;

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
			blockTransform.localPosition = TurnLocalPosition(blockTransform.localPosition, TurnDirection.Left);
		}
	}

	public void TurnRight()
	{
		foreach(Transform blockTransform in transform)
		{
			blockTransform.localPosition = TurnLocalPosition(blockTransform.localPosition, TurnDirection.Right);
		}
	}

	public List<Vector3> TurnedWorldPositions(TurnDirection direction)
	{
		List<Vector3> result = new List<Vector3>();

		foreach(Transform blockTransform in transform)
		{
			Vector3 newWorldPosition = transform.position + TurnLocalPosition(blockTransform.localPosition, direction);
			result.Add(newWorldPosition);
		}

		return result;
	}

	private Vector3 TurnLocalPosition(Vector3 currentPosition, TurnDirection direction = TurnDirection.Left)
	{
		float negative = (direction == TurnDirection.Left) ? -1.0f : 1.0f;

		return new Vector3(
			-negative * (currentPosition.y + TurnAxis.y) - TurnAxis.x,
			negative * (currentPosition.x + TurnAxis.x) - TurnAxis.y,
			0
		);
	}

	public void MoveToMapPosition(int x, int y)
	{
		transform.position = Position.MapToWorld(x, y);
	}
}