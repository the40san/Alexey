using UnityEngine;

namespace UI
{

public class Next : MonoBehaviour {
	private static Next _instance;

	public static Next Instance
	{
		get {
			if (_instance == null)
			{
				_instance = (Next)FindObjectOfType(typeof(Next));
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

}