using UnityEngine;
using UnityEngine.Assertions;

public class Map : MonoBehaviour {

	public class BlockStackingException : System.ApplicationException {}

	public const int Width = 10;
	public const int Height = 20;

	private BlockState[,] mapState;

	public void Start()
	{
		InitMapState();
	}

	private void InitMapState()
	{
		mapState = new BlockState[Width, Height];
	}

	public bool IsEmptyAt(int x, int y)
	{
		return this.mapState[x, y] == BlockState.Empty;
	}

	public void AddBlockAt(int x, int y, BlockState state)
	{
		Assert.AreNotEqual(state, BlockState.Empty);

		if (this.IsEmptyAt(x, y))
		{
			this.mapState[x, y] = state;
			var newBlock = Spawner.SpawnObject("TetriminoBlock", this.gameObject).GetComponent<TetriminoBlock>();
			newBlock.SetBlockState(state);
			newBlock.MoveToMapPosition(x, y);
		}
		else
		{
			throw new BlockStackingException();
		}
	}

	public void PileTetrimino(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = block.ToMapPosition();

			AddBlockAt((int)mapPosition.x, (int)mapPosition.y, block.GetBlockState());
			Debug.Log("stack: " + mapPosition.ToString());
		}
		Spawner.Destroy(tetrimino);
	}

	public bool IsPiling(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = block.ToMapPosition();

			if (mapPosition.y == 0 ||
				mapState[(int)mapPosition.x, (int)mapPosition.y - 1] != BlockState.Empty)
				{
					return true;
				}
		}
		return false;
	}

	public bool CanMoveRight(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = block.ToMapPosition();

			if (mapPosition.x + 1 >= Width)
			{
				return false;
			}
		}

		return true;
	}
	public bool CanMoveLeft(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = block.ToMapPosition();

			if (mapPosition.x == 0)
			{
				return false;
			}
		}

		return true;
	}
}
