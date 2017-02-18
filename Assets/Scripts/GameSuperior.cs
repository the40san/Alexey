using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSuperior : MonoBehaviour {

	private InputController inputController;
	private Player player;
	private Map map;

	void Start () {
		this.inputController = Spawner.SpawnObject("InputController", this.gameObject).GetComponent<InputController>();
		this.player = Spawner.SpawnObject("Player", this.gameObject).GetComponent<Player>();
		this.map = Spawner.SpawnObject("Map", this.gameObject).GetComponent<Map>();

		this.inputController.AddKeyAction(new PlayerIngameKeyAction(player));
		player.map = map;
	}
}
