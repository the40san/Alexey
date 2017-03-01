using UnityEngine;
using System.Collections.Generic;

public class TetriminoTurn {
	private Tetrimino tetrimino;
	private TurnDirection direction;
	private Vector3 additionalTurnAxis;

	public TetriminoTurn(Tetrimino tetrimino, TurnDirection direction, Vector3 additionalTurnAxis)
	{
		this.tetrimino = tetrimino;
		this.direction = direction;
		this.additionalTurnAxis = additionalTurnAxis;
	}

	public void TurnTetrimino()
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			blockTransform.localPosition = TurnLocalPosition(blockTransform.localPosition);
		}

		tetrimino.transform.Translate(additionalTurnAxis);
	}

	public Vector3 TurnLocalPosition(Vector3 currentPosition)
	{
		float negative = (this.direction == TurnDirection.Left) ? -1.0f : 1.0f;

		return new Vector3(
			-negative * (currentPosition.y + tetrimino.TurnAxis.y) - tetrimino.TurnAxis.x,
			negative * (currentPosition.x + tetrimino.TurnAxis.x) - tetrimino.TurnAxis.y,
			0
		);
	}

	public List<Vector3> TurnedWorldPositions()
	{
		List<Vector3> result = new List<Vector3>();

		foreach(Transform blockTransform in this.tetrimino.transform)
		{
			Vector3 newWorldPosition = this.tetrimino.transform.position + TurnLocalPosition(blockTransform.localPosition) + additionalTurnAxis;
			result.Add(newWorldPosition);
		}

		return result;
	}
}
