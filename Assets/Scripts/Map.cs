using UnityEngine;
using UnityEngine.Assertions;

public class Map : MonoBehaviour {

	public class BlockStackingException : System.ApplicationException {}

	public const int Width = 10;
	public const int Height = 20;

	private BlockState[,] mapState;

	//temporary
	public GameObject dispenser;


	public void Start()
	{
		InitMapState();
		GameObject gameobject = dispenser.GetComponent<TetriminoDispenser>().CreateNext();
		gameobject.transform.SetParent(this.gameObject.transform);
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
			var newBlock = Spawner.SpawnObject("TetriminoBlock", this.gameObject);
			newBlock.GetComponent<TetriminoBlock>().SetBlockState(state);
		}
		else
		{
			throw new BlockStackingException();
		}
	}
}
