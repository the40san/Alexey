using UnityEngine;
using UnityEngine.Assertions;

public class TetriminoBlock : MonoBehaviour, IMovable {
	private BlockState blockState;

	public void SetBlockState(BlockState newBlockState)
	{
		Assert.AreNotEqual(newBlockState, BlockState.Empty);
		if (blockState != newBlockState)
		{
			float r = (((int)newBlockState & 0xff0000) >> 16) / 255f;
			float g = (((int)newBlockState & 0x00ff00) >> 8)/ 255f;
			float b = ((int)newBlockState & 0x0000ff) / 255f;

			this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(r, g, b, 1f));
			this.blockState = newBlockState;
		}
	}

	public BlockState GetBlockState()
	{
		return blockState;
	}

	public void MoveToMapPosition(int x, int y)
	{
		float nx = x - Map.Width / 2 + 0.5f;
		float ny = y - Map.Height / 2 + 0.5f;
		float nz = 0;
		transform.position = new Vector3(nx, ny, nz);
	}

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
}
