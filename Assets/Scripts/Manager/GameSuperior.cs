using UnityEngine;

public class GameSuperior : MonoBehaviour {

	private InputController inputController;
	private Player player;
	private Map map;

	void Start () {
		this.inputController = Spawner.SpawnObject("InputController", this.gameObject).GetComponent<InputController>();
		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();

		ScoreBoard.Instance.gameObject.SetActive(false);
		//StartTetris();
	}

	void StartTetris()
	{
		this.player = Spawner.SpawnObject("Player", this.gameObject).GetComponent<Player>();
		this.inputController.AddKeyAction(new PlayerIngameKeyAction(player));
		player.map = map;
		ScoreBoard.Instance.gameObject.SetActive(true);
		ScoreBoard.Instance.Clear();
	}
}
