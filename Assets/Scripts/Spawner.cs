using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour {
	public static GameObject SpawnBlock(string prefabName, BlockState state, GameObject parent = null)
	{
		Object resource = Resources.Load(ToPrefabPath(prefabName));

		Assert.IsNotNull(resource, "Could not spawn" + prefabName);

		GameObject newSpawn = Instantiate(resource) as GameObject;
		newSpawn.name = newSpawn.name.Replace("(Clone)", "");
		newSpawn.GetComponent<TetrominoBlock>().SetBlockState(state);

		if (parent != null)
		{
			newSpawn.transform.SetParent(parent.transform, false);
		}

		return newSpawn;
	}

	private static string ToPrefabPath(string prefabName)
	{
		return "Prefabs/" + prefabName;
	}

	public static void DestroyObject(GameObject obj)
	{
		Destroy(obj);
	}
}