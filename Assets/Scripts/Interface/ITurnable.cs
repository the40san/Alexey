using UnityEngine;
using System.Collections.Generic;
public interface ITurnable
{
	void TurnLeft();
	void TurnRight();
	List<Vector3> TurnedWorldPositions(TurnDirection direction);
}

public enum TurnDirection {
	Left,
	Right
}