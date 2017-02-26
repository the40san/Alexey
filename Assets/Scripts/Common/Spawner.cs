using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour {
	public static GameObject SpawnObject(string prefabName, GameObject parent = null)
	{
		Object resource = Resources.Load(ToPrefabPath(prefabName));

		Assert.IsNotNull(resource, "Could not spawn: " + prefabName);

		GameObject newSpawn = Instantiate(resource) as GameObject;
		newSpawn.name = newSpawn.name.Replace("(Clone)", "");

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
}