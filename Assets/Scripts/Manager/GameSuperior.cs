using UnityEngine;

public class GameSuperior : MonoBehaviour {

	private InputController inputController;
	private Player player;
	private Map map;

	void Start () {
		ScoreBoard.Instance.gameObject.SetActive(false);
		StartTetris();
	}

	void StartTetris()
	{
		this.inputController = Spawner.SpawnObject("InputController", this.gameObject).GetComponent<InputController>();
		this.player = Spawner.SpawnObject("Player", this.gameObject).GetComponent<Player>();
		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();

		this.inputController.AddKeyAction(new PlayerIngameKeyAction(player));
		player.map = map;
		ScoreBoard.Instance.Clear();
		ScoreBoard.Instance.gameObject.SetActive(true);
	}
}
