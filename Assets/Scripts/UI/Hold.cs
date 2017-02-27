using UnityEngine;

public class Hold : MonoBehaviour {
	private static Hold _instance;
	public static Hold Instance
	{
		get {
			if (_instance == null)
			{
				_instance = (Hold)FindObjectOfType(typeof(Hold));
			}

			return _instance;
		}
	}

	public void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
}