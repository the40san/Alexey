﻿using UnityEngine;
using System;


namespace UI
{

public class BlinkingText : MonoBehaviour {
	void Update () {
		float alpha = (DateTime.Now.Second % 2 == 0) ? 1f : 0f;
		this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
	}
}

}