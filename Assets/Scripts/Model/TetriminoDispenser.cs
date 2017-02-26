using System.Collections.Generic;
using UnityEngine;

public class TetriminoDispenser : MonoBehaviour {
	private List<TetriminoShape> shapeList;
	private List<TetriminoShape> temporaryList;

	public void Awake () {
		this.shapeList = new List<TetriminoShape>();
		this.temporaryList = new List<TetriminoShape>();

		// I-Tetrimio
		BlockState[,] ITetriminoMap = CreateBlockMap(
			BlockState.Cyan,
			new int[,] {
				{0, 0, 0, 0},
				{1, 1, 1, 1},
				{0, 0, 0, 0},
				{0, 0, 0, 0}
			}
		);

		// O-Tetrimio
		BlockState[,] OTetriminoMap = CreateBlockMap(
			BlockState.Yellow,
			new int[,] {
				{0, 0, 0, 0},
				{0, 1, 1, 0},
				{0, 1, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// S-Tetrimio
		BlockState[,] STetriminoMap = CreateBlockMap(
			BlockState.YellowGreen,
			new int[,] {
				{0, 1, 0, 0},
				{0, 1, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// Z-Tetrimio
		BlockState[,] ZTetriminoMap = CreateBlockMap(
			BlockState.Red,
			new int[,] {
				{0, 0, 1, 0},
				{0, 1, 1, 0},
				{0, 1, 0, 0},
				{0, 0, 0, 0}
			}
		);

		// J-Tetrimio
		BlockState[,] JTetriminoMap = CreateBlockMap(
			BlockState.Blue,
			new int[,] {
				{0, 1, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 1, 0},
				{0, 0, 0, 0}
			}
		);

		// L-Tetrimio
		BlockState[,] LTetriminoMap = CreateBlockMap(
			BlockState.Orange,
			new int[,] {
				{0,	0, 1, 0},
				{0, 0, 1, 0},
				{0, 1, 1, 0},
				{0, 0, 0, 0}
			}
		);


		// T-Tetrimio
		BlockState[,] TTetriminoMap = CreateBlockMap(
			BlockState.Purple,
			new int[,] {
				{0,	1, 0, 0},
				{1, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 0, 0, 0}
			}
		);

		shapeList.Add( new TetriminoShape(ITetriminoMap, new Vector3(1, 1, 0) ));
		shapeList.Add( new TetriminoShape(OTetriminoMap, new Vector3(1.5f, 1.5f, 0) ));
		shapeList.Add( new TetriminoShape(STetriminoMap, new Vector3(1, 1, 0) ));
		shapeList.Add( new TetriminoShape(ZTetriminoMap, new Vector3(1, 1, 0) ));
		shapeList.Add( new TetriminoShape(JTetriminoMap, new Vector3(1, 2, 0) ));
		shapeList.Add( new TetriminoShape(LTetriminoMap, new Vector3(1, 2, 0) ));
		shapeList.Add( new TetriminoShape(TTetriminoMap, new Vector3(1, 1, 0) ));
	}

	public GameObject CreateNext()
	{
		if (temporaryList.Count == 0) {
			temporaryList = new List<TetriminoShape>(shapeList);
		}

		int at = Random.Range(0, temporaryList.Count);
		TetriminoShape thisTime = temporaryList[at];
		temporaryList.RemoveAt(at);

		return thisTime.CreateTetorimino();
	}

	private BlockState[,] CreateBlockMap(BlockState state, int[,] map)
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