using UnityEngine;
using System.Collections.Generic;

public class Tetrimino : MonoBehaviour, IMovable {
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

	public void MoveToMapPosition(int x, int y)
	{
		float nx = x - Map.Width / 2 + 0.5f;
		float ny = y - Map.Height / 2 + 0.5f;
		float nz = 0;
		transform.position = new Vector3(nx, ny, nz);
	}
}