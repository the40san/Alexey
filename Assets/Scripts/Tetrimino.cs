using UnityEngine;

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
}