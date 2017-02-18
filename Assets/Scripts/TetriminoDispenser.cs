using System.Collections.Generic;
using UnityEngine;

public class TetriminoDispenser : MonoBehaviour {

	private List<TetriminoShape> shapeList;

	public void Awake () {
		this.shapeList = new List<TetriminoShape>();

		// O-Tetrimio
		BlockState[,] OTetriminoMap = CreateMap(
			BlockState.Red,
			new int[,] {
				{0, 0, 0, 0},
				{0, 1, 1, 0},
				{0, 1, 1, 0},
				{0, 0, 0, 0}
			}
		);

		shapeList.Add( new TetriminoShape(OTetriminoMap) );
	}

	public GameObject CreateNext()
	{
		return shapeList[Random.Range(0, shapeList.Count)].CreateTetorimino();
	}

	private BlockState[,] CreateMap(BlockState state, int[,] map)
	{
		BlockState[,] result = new BlockState [TetriminoShape.Width, TetriminoShape.Height];

		for (int x = 0; x < TetriminoShape.Width; x++)
		{
			for (int y = 0; y < TetriminoShape.Height; y++)
			{
				result[x, y] = (map[x,y] == 0) ? BlockState.Empty : state;
			}
		}

		return result;
	}
}