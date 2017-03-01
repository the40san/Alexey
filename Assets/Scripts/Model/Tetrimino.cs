using UnityEngine;

public class Tetrimino : MonoBehaviour, IMovable {
	public Vector3 TurnAxis {get;set;}
	public TetriminoShape Shape {get; set;}

	public void MoveLeft()
	{
		transform.Translate(Vector3.left);
	}
	public void MoveRight()
	{
		transform.Translate(Vector3.right);
	}

	public void MoveDown()
	{
		transform.Translate(Vector3.down);
	}

	public void MoveToMapPosition(int x, int y)
	{
		transform.position = Position.MapToWorld(x, y);
	}
}