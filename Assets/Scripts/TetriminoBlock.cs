using UnityEngine;
using UnityEngine.Assertions;

public class TetriminoBlock : MonoBehaviour {
	private BlockState blockState;

	void Start()
	{
		SetBlockState(BlockState.Red);
	}

	public void SetBlockState(BlockState newBlockState)
	{
		Assert.AreNotEqual(newBlockState, BlockState.Empty);
		if (blockState != newBlockState)
		{
			float r = ((int)newBlockState & 0xff0000) / 255f;
			float g = ((int)newBlockState & 0x00ff00) / 255f;
			float b = ((int)newBlockState & 0x0000ff) / 255f;

			this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(r, g, b, 1f));
			this.blockState = newBlockState;
		}
	}

	public void MoveToMapPosition(int x, int y)
	{
		float nx = x - Map.Width / 2 + 0.5f;
		float ny = y - Map.Height / 2 + 0.5f;
		float nz = 0;
		transform.position = new Vector3(nx, ny, nz);
	}

	public Vector3 ToMapPosition()
	{
		float x = transform.position.x + Map.Width / 2 - 0.5f;
		float y = transform.position.y + Map.Height / 2 - 0.5f;
		float z = transform.position.z;

		return new Vector3(x, y, z);
	}
}
