using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class Map : MonoBehaviour {
	public class BlockStackingException : System.ApplicationException {}
	public const int Width = 10;
	public const int Height = 20;
	private TetriminoBlock[,] mapState;

	public void Awake()
	{
		InitMapState();
	}

	private void InitMapState()
	{
		mapState = new TetriminoBlock[Width, Height + 4];
	}

	public bool IsEmptyAt(int x, int y)
	{
		return this.mapState[x, y] == null;
	}

	public bool IsEmptyAt(Vector3 mapPosition)
	{
		return IsEmptyAt((int)mapPosition.x, (int)mapPosition.y);
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
			Vector3 mapPosition = Position.WorldToMap(block.transform.position);

			AddBlockAt((int)mapPosition.x, (int)mapPosition.y, block.GetBlockState());
		}
	}

	public bool IsPiling(Tetrimino tetrimino)
	{
		foreach(Transform blockTransform in tetrimino.transform)
		{
			var block = blockTransform.gameObject.GetComponent<TetriminoBlock>();
			Vector3 mapPosition = Position.WorldToMap(block.transform.position);

			if (mapPosition.y == 0 ||
				!IsEmptyAt(mapPosition + Vector3.down))
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
			Vector3 mapPosition = Position.WorldToMap(block.transform.position);

			if (mapPosition.x + 1 >= Width ||
				!IsEmptyAt(mapPosition + Vector3.right))
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
			Vector3 mapPosition = Position.WorldToMap(block.transform.position);

			if (mapPosition.x == 0 ||
				!IsEmptyAt(mapPosition + Vector3.left))
			{
				return false;
			}
		}

		return true;
	}

	public bool CanTurn(ITurnable turnable, TurnDirection direction)
	{
		List<Vector3> worldPositions = turnable.TurnedWorldPositions(direction);

		foreach(Vector3 pos in worldPositions)
		{
			Vector3 mapPosition = Position.WorldToMap(pos);
			if (!IsInMap(pos) || !IsEmptyAt(mapPosition))
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
		for(int y = 0; y < Height - 1; y++)
		{
			if (IsEmptyLine(y) && !IsEmptyLine(y + 1))
			{
				PackLine(y);
				y = -1; // Restart Loop for Double, Triple, Tetris
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

	private bool IsInMap(Vector3 worldPosition)
	{
		Vector3 mapPosition = Position.WorldToMap(worldPosition);
		if (mapPosition.x < 0 ||
			mapPosition.x >= Width ||
			mapPosition.y < 0 ||
			mapPosition.y >= Height
		)
		{
			return false;
		}
		return true;
	}
}
