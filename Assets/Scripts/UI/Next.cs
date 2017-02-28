using UnityEngine;
using System.Collections.Generic;

namespace UI
{

public class Next : MonoBehaviour {
	private static Next _instance;

	public GameObject nextHolder1;
	public GameObject nextHolder2;
	public GameObject nextHolder3;

	public const int DisplayingForecastNum = 3;
	public List<Tetrimino> displayingTetriminos;

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

		displayingTetriminos = new List<Tetrimino>();
	}

	public void Clear()
	{
		for(int i = 0; i < displayingTetriminos.Count; i++)
		{
			Spawner.Destroy(displayingTetriminos[i].gameObject);
		}
		displayingTetriminos.Clear();
	}

	public void UpdateQueue(TetriminoShape newTetriminoShape)
	{
		Tetrimino adding = newTetriminoShape.CreateTetorimino().GetComponent<Tetrimino>();
		adding.transform.position = Vector3.zero;
		adding.transform.Translate(adding.TurnAxis);
		adding.gameObject.SetActive(true);

		this.displayingTetriminos.Add(adding);

		if (displayingTetriminos.Count > DisplayingForecastNum)
		{
			Spawner.Destroy(displayingTetriminos[0].gameObject);
			displayingTetriminos.RemoveAt(0);
		}

		Remap();
	}

	private void Remap()
	{
		GameObject[] holders = new GameObject[] {nextHolder1, nextHolder2, nextHolder3};

		for(int i = 0; i < displayingTetriminos.Count; i++)
		{
			if (displayingTetriminos[i] == null) {
				continue;
			}

			displayingTetriminos[i].transform.SetParent(holders[i].transform, false);
		}
	}
}

}