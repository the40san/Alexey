using UnityEngine;
using UnityEngine.Assertions;

public class Map : MonoBehaviour {

	public class BlockStackingException : System.ApplicationException {}

	public const int Width = 10;
	public const int Height = 20;

	private TetriminoBlock[,] mapState;

	public void Start()
	{
		InitMapState();
	}

	private void InitMapState()
	{
		mapState = new TetriminoBlock[Width, Height];
	}

	public bool IsEmptyAt(int x, int y)
	{
		return this.mapState[x, y] == null;
	}

	public void AddBlockAt(int x, int y, BlockState state)
	{
		Assert.AreNotEqual(state, BlockState.Empty);

		if (this.IsEmptyAt(x, y))
		{
			var newBlock = Spawner.SpawnObject("TetriminoBlock", this.gameObject).GetComponent<TetriminoBlock>();
			newBlock.SetBlockState(state);
			newBlock.MoveToMapPosition(x, y);
			this.mapState[x, y] = newBlock;
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
		}
		Spawner.Destroy(tetrimino.gameObject);
	}

	public bool IsPiling(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = block.ToMapPosition();

			if (mapPosition.y == 0 ||
				!IsEmptyAt((int)mapPosition.x, (int)mapPosition.y - 1))
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

			if (mapPosition.x + 1 >= Width ||
				!IsEmptyAt((int)mapPosition.x + 1, (int)mapPosition.y))
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

			if (mapPosition.x == 0 ||
				!IsEmptyAt((int)mapPosition.x - 1, (int)mapPosition.y))
			{
				return false;
			}
		}

		return true;
	}

	public void CleanLines()
	{
		for(int y = 0; y < Height; y++)
		{
			if (IsFilledLine(y)) { CleanLine(y); }
		}
	}

	private void CleanLine(int y)
	{
		for (int x = 0; x < Width; x++) {
			Spawner.Destroy(mapState[x,y].gameObject);
			mapState[x,y] = null;
		}
	}

	public int FilledLineCount()
	{
		int count = 0;
		for(int y = 0; y < Height; y++)
		{
			if (IsFilledLine(y)) { count++; }
		}
		return count;
	}

	private bool IsFilledLine(int y)
	{
		for (int x = 0; x < Width; x++)
		{
			if (IsEmptyAt(x, y))
			{
				return false;
			}
		}

		return true;
	}

	private bool IsEmptyLine(int y)
	{
		for (int x = 0; x < Width; x++)
		{
			if (!IsEmptyAt(x, y))
			{
				return false;
			}
		}

		return true;
	}

	public void PackLines()
	{
		for(int y = 0; y < Height; y++)
		{
			if (IsEmptyLine(y))
			{
				PackLine(y);
			}
		}
	}

	private void PackLine(int yBegin)
	{
		for (int x = 0; x < Width; x++)
		{
			for (int y = yBegin; y < Height - 1; y++)
			{
				mapState[x, y] = mapState[x, y + 1];

				if (mapState[x, y] != null)
				{
					mapState[x, y].MoveDown();
				}
			}

			mapState[x, Height - 1] = null;
		}
	}
}
