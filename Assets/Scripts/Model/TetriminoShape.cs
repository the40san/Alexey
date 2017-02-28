using UnityEngine;
using UnityEngine.Assertions;

public class TetriminoShape
{
	public const int Width = 4;
	public const int Height = 4;

	public BlockState[,] shape;
	public Vector3 turnAxis;

	public TetriminoShape(BlockState[,] shape, Vector3 turnAxis)
	{
		this.shape = shape;
		this.turnAxis = turnAxis;
	}

	public GameObject CreateTetorimino()
	{
		Tetrimino tetrimino = Spawner.SpawnObject("Tetrimino").GetComponent<Tetrimino>();

		Assert.AreEqual(shape.GetLength(0), Width);
		Assert.AreEqual(shape.GetLength(1), Height);


		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				if (shape[x,y] != BlockState.Empty)
				{
					TetriminoBlock block = Spawner.SpawnObject("TetriminoBlock", tetrimino.gameObject).GetComponent<TetriminoBlock>();
					block.SetBlockState(shape[x,y]);
					block.transform.position = new Vector3(-x, -y, 0);
				}
			}
		}
		// TODO
		tetrimino.transform.Translate(0.5f, 0.5f, 0);
		tetrimino.TurnAxis = turnAxis;
		tetrimino.Shape = this;

		return tetrimino.gameObject;
	}
}