using UnityEngine;
using UnityEngine.Assertions;

public class TetrominoBlock : MonoBehaviour {
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
}
