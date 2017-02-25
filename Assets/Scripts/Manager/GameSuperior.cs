using UnityEngine;

public class GameSuperior : MonoBehaviour {

	private InputController inputController;
	private Player player;
	private Map map;

	public static GameSuperior Instance {
		get {
			if (_instance == null)
			{
				_instance = (GameSuperior)FindObjectOfType(typeof(GameSuperior));
			}
			return _instance;
		}
	}
	private static GameSuperior _instance;

	public void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		this.inputController = Spawner.SpawnObject("InputController", this.gameObject).GetComponent<InputController>();
		this.inputController.AddKeyAction(new TitleScreenKeyAction());
		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();

		ScoreBoard.Instance.gameObject.SetActive(false);
	}

	public void StartTetris()
	{
		if (player != null)
		{
			return;
		}

		this.player = Spawner.SpawnObject("Player", this.gameObject).GetComponent<Player>();
		this.inputController.Clear();
		this.inputController.AddKeyAction(new PlayerIngameKeyAction(player));
		player.map = map;
		ScoreBoard.Instance.gameObject.SetActive(true);
		ScoreBoard.Instance.Clear();
	}
}
