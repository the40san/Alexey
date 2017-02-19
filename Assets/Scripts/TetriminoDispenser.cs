using System.Collections.Generic;
using UnityEngine;

public class TetriminoDispenser : MonoBehaviour {
	private List<TetriminoShape> shapeList;

	public void Awake () {
		this.shapeList = new List<TetriminoShape>();

		// I-Tetrimio
		BlockState[,] ITetriminoMap = CreateMap(
			BlockState.Cyan,
			new int[,] {
				{0, 0, 0, 0},
				{1, 1, 1, 1},
				{0, 0, 0, 0},
				{0, 0, 0, 0}
			}
		);

		// O-Tetrimio
		BlockState[,] OTetriminoMap = CreateMap(
			BlockState.Yellow,
			new int[,] {
				{0, 0, 0, 0},
				{0, 1, 1, 0},
				{0, 1, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// S-Tetrimio
		BlockState[,] STetriminoMap = CreateMap(
			BlockState.YellowGreen,
			new int[,] {
				{0, 1, 0, 0},
				{0, 1, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// Z-Tetrimio
		BlockState[,] ZTetriminoMap = CreateMap(
			BlockState.Red,
			new int[,] {
				{0, 0, 1, 0},
				{0, 1, 1, 0},
				{0, 1, 0, 0},
				{0, 0, 0, 0}
			}
		);

		// J-Tetrimio
		BlockState[,] JTetriminoMap = CreateMap(
			BlockState.Blue,
			new int[,] {
				{0, 1, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// L-Tetrimio
		BlockState[,] LTetriminoMap = CreateMap(
			BlockState.Orange,
			new int[,] {
				{0,	0, 1, 0},
				{0, 0, 1, 0},
				{0, 1, 1, 0},
				{0, 0, 0, 0}
			}
		);


		// T-Tetrimio
		BlockState[,] TTetriminoMap = CreateMap(
			BlockState.Purple,
			new int[,] {
				{0,	1, 0, 0},
				{1, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 0, 0, 0}
			}
		);

		shapeList.Add( new TetriminoShape(ITetriminoMap, new Vector3(1, 0, 0) ));
		shapeList.Add( new TetriminoShape(OTetriminoMap, new Vector3(0.5f, 0.5f, 0) ));
		shapeList.Add( new TetriminoShape(STetriminoMap, new Vector3(1, 1, 0) ));
		shapeList.Add( new TetriminoShape(ZTetriminoMap, new Vector3(1, 1, 0) ));
		shapeList.Add( new TetriminoShape(JTetriminoMap, new Vector3(1, 0, 0) ));
		shapeList.Add( new TetriminoShape(LTetriminoMap, new Vector3(1, 0, 0) ));
		shapeList.Add( new TetriminoShape(TTetriminoMap, new Vector3(1, 1, 0) ));
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