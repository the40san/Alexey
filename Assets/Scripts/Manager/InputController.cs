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

 	public void Update()
    {
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			foreach(var a in keyActions)
			{
				a.OnKeyDown();
			}
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			foreach(var a in keyActions)
			{
				a.OnKeyRight();
			}
		}
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			foreach(var a in keyActions)
			{
				a.OnKeyLeft();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach(var a in keyActions)
			{
				a.OnKeySpace();
			}
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			foreach(var a in keyActions)
			{
				a.OnKeyTurnRight();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			foreach(var a in keyActions)
			{
				a.OnKeyTurnLeft();
			}
		}
    }
}
