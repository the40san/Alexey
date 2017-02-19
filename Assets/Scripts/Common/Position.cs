using UnityEngine;

public class Position
{
	public static Vector3 WorldToMap(Vector3 worldPosition)
	{
		return new Vector3(
			worldPosition.x + Map.Width / 2 - 0.5f,
			worldPosition.y + Map.Height/ 2 - 0.5f,
			0
		);
	}

	public static Vector3 MapToWorld(int x, int y)
	{
		float nx = x - Map.Width / 2 + 0.5f;
		float ny = y - Map.Height / 2 + 0.5f;
		float nz = 0;
		return new Vector3(nx, ny, nz);
	}
}