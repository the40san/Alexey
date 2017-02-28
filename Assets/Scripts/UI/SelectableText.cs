using UnityEngine;
using UnityEngine.UI;

namespace UI
{

public class SelectableText : MonoBehaviour {
	public bool isSelected;

	private Color defaultColor;

	public void Start()
	{
		this.defaultColor = this.gameObject.GetComponent<Text>().color;
	}

	void Update () {
		Color color = this.isSelected ? Color.white : defaultColor;
		this.gameObject.GetComponent<Text>().color = color;
	}
}

}