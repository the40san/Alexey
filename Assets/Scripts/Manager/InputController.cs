using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	private List<IKeyAction> keyActions;

    public void Awake()
	{
		keyActions = new List<IKeyAction>();
	}

	public void AddKeyAction(IKeyAction action)
	{
		keyActions.Add(action);
	}
	public void Clear()
	{
		keyActions.Clear();
	}

 	public void Update()
    {
		List<IKeyAction> temporaryList = new List<IKeyAction>(keyActions);
		if (Input.anyKeyDown) {
			foreach(var a in temporaryList)
			{
				a.OnAnyKey();
			}
		}

		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeyDown();
			}
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeyRight();
			}
		}
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeyLeft();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeySpace();
			}
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeyTurnRight();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			foreach(var a in temporaryList)
			{
				a.OnKeyTurnLeft();
			}
		}
    }
}
