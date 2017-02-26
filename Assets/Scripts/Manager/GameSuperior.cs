using UnityEngine;

public class GameSuperior : MonoBehaviour {

	private InputController inputController;

	private UIController uiController;
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
		this.uiController = Spawner.SpawnObject("UIController", this.gameObject).GetComponent<UIController>();
		this.inputController = Spawner.SpawnObject("InputController", this.gameObject).GetComponent<InputController>();
		Spawner.SpawnObject("AudioController", this.gameObject);
		GoToTitle();
	}

	public void GoToTitle()
	{
		this.uiController.ScoreBoard.gameObject.SetActive(false);
		this.uiController.Title.gameObject.SetActive(true);
		this.uiController.GameOver.gameObject.SetActive(false);

		this.inputController.AddKeyAction(new TitleScreenKeyAction());

		if (map != null) {
			Spawner.Destroy(map.gameObject);
		}

		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();
	}

	public void StartTetris()
	{
		if (map != null) {
			Spawner.Destroy(map.gameObject);
		}
		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();

		if (player != null)
		{
			Spawner.Destroy(player.gameObject);
		}

		this.player = Spawner.SpawnObject("Player", this.gameObject).GetComponent<Player>();

		this.inputController.Clear();
		this.inputController.AddKeyAction(new PlayerIngameKeyAction(player));

		player.map = map;

		uiController.Title.gameObject.SetActive(false);
		uiController.ScoreBoard.gameObject.SetActive(true);
		uiController.GameOver.gameObject.SetActive(false);
		uiController.ScoreBoard.Clear();

		AudioController.Instance.StartBgm();
	}

	public void EndTetris()
	{
		AudioController.Instance.PlaySe(SfxId.GameOver);
		AudioController.Instance.StopBgm();

		this.uiController.GameOver.gameObject.SetActive(true);
		this.inputController.Clear();
		this.inputController.AddKeyAction(
			new GameOverKeyAction(this.uiController.GameOver.GameOverMenu)
		);

		this.player.gameObject.SetActive(false);
	}
}
